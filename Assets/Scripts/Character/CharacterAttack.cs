using UnityEngine;
using System.Collections;

public class CharacterAttack : MonoBehaviour {

	public int damage = 10;
	public float attackSpeed = 2f;
	public float swordSpeed = 2f;
	public float swordAnimTime = .01f;
	public float range = .3f;
	public Camera cam;

	Rigidbody origin;
	Vector3 target;
	LineRenderer swordRenderer;
	private float curLength;

	RaycastHit hit;
	private float timer;
	private float attackTimer = 0f;
	private bool attacking = false;
	private bool thrust = true;
	private Vector3 vertex;
	// Use this for initialization
	void Awake () {
		curLength = 0f;
		timer = 0f;
		swordRenderer = GetComponent<LineRenderer>();
		timer = attackSpeed;
		origin = GetComponent<Rigidbody> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (timer < attackSpeed) {
			timer += Time.deltaTime;
		}
		target = cam.ScreenToWorldPoint(Input.mousePosition) - origin.transform.position;
		
		target.z = 0;
		target = target.normalized;

		if (Input.GetButton ("Fire1") && timer >= attackSpeed && !attacking) {
			attacking = true;
			timer = 0f;
			swordRenderer.enabled = true;
			//swordRenderer.SetPosition(0, origin.transform.position);
			//swordRenderer.SetPosition(1, cam.ScreenToWorldPoint(Input.mousePosition));



			thrust = true;

		}

		if (attacking) {
			attackAnim();
		}
	}
	
	void attackAnim()
	{
		swordRenderer.SetPosition (0, origin.transform.position);
		if (thrust)
		{
			if (curLength < range) {
				curLength += swordSpeed * Time.deltaTime;
				vertex = origin.transform.position + target * curLength;
				swordRenderer.SetPosition (1, vertex);
			}
			else{
				thrust = false;
			}
		}
		//hold
		else{
			attackTimer += Time.deltaTime;
			if(attackTimer > swordAnimTime)
			{
				curLength -= swordSpeed * Time.deltaTime;
				vertex = origin.transform.position + target * curLength;
				swordRenderer.SetPosition (1, vertex);

				if(curLength <= 0f)
				{
					attacking = false;
					attackTimer = 0f;
					swordRenderer.enabled = false;
					curLength = 0f;
					return;
				}
			}
			else{
				vertex = origin.transform.position + target * curLength;
				swordRenderer.SetPosition (1, vertex);

			}
		}

		if (Physics.Raycast (origin.transform.position, target, out hit, curLength)) {
			switch(hit.transform.gameObject.tag)
			{
				case "Enemy":
					//Output message
					EnemyHealth enemyHealth = hit.collider.GetComponentInParent <EnemyHealth> ();
					if(enemyHealth != null)
					{
						enemyHealth.damage(damage, target);
					}
					break;
			}

		}

	}
}