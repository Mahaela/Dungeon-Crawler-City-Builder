using UnityEngine;
using System.Collections;

public class CharacterAttack : MonoBehaviour {

	public int damage = 10;
	public float attackSpeed = 2f; //how fast between attacks
	public float swordSpeed = 2f; //how fast sword moves
	public float swordAnimTime = .01f; //time sword stays at max range before pulling back
	public float range = .3f; //range of attack
	public Camera cam;

	Rigidbody2D origin;
	Vector3 target;
	LineRenderer swordRenderer;
	private float curLength;

	RaycastHit hit;
	private float timer;
	private float attackTimer = 0f;
	private bool attacking = false;
	private bool thrust = true;
	private Vector3 vertex;

	// initialization
	void Awake () {
		curLength = 0f;
		timer = 0f;
		swordRenderer = GetComponent<LineRenderer>();
		timer = attackSpeed;
		origin = GetComponent<Rigidbody2D> ();

	}
	
	// Each update...
	void Update () {
		//recharge attack
		if (timer < attackSpeed) {
			timer += Time.deltaTime;
		}
		//this sets the target direction of sword towards mouse position, then normalizes to get unit vector
		target = cam.ScreenToWorldPoint(Input.mousePosition) - origin.transform.position;
		target.z = 0;
		target = target.normalized;

		//if you click mouse, and you are allowed to attack
		if (Input.GetButton ("Fire1") && timer >= attackSpeed && !attacking) {
			attacking = true; //you are attacking
			timer = 0f;

			swordRenderer.enabled = true; //enables the linerenderer in order to draw line
			//you are thrusting outwards first
			thrust = true;

		}
		//if you're attacking, call animation method
		if (attacking) {
			attackAnim();
		}
	}
	
	void attackAnim()
	{
		//sets point 0 (first end of line) to center of character
		swordRenderer.SetPosition (0, origin.transform.position);
		//if sword moving outwards
		if (thrust)
		{
			if (curLength < range) {
				curLength += swordSpeed * Time.deltaTime; //increase distance = speed * time
				//vertex is current tip of sword, its a currentlength in the direction of the target direction
				vertex = origin.transform.position + target * curLength; 
				//set other end of sword to vertex
				swordRenderer.SetPosition (1, vertex);
			}
			else{
				thrust = false; //once sword reaches max range stop thrusting
			}
		}
		//this is when you pull back
		else{
			attackTimer += Time.deltaTime; //count
			if(attackTimer > swordAnimTime) //if its done holding the length
			{
				curLength -= swordSpeed * Time.deltaTime; //lose length according to d = v*t
				vertex = origin.transform.position + target * curLength; //update vertex, same way
				swordRenderer.SetPosition (1, vertex); //set tip, same way
				//if your sword loses all length, the attack is over.
				if(curLength <= 0f)
				{
					attacking = false;
					attackTimer = 0f;
					swordRenderer.enabled = false;
					curLength = 0f;
					return;
				}
			}
			//stay with current length, just update the sword according to movement of mouse
			else{
				vertex = origin.transform.position + target * curLength;
				swordRenderer.SetPosition (1, vertex);

			}
		}
		//check hit
		//cast a ray with curLength in same direction as sword
		if (Physics.Raycast (origin.transform.position, target, out hit, curLength)) {
			switch(hit.transform.gameObject.tag) //take the tag
			{
				//if you hit object tagged enemy
				case "Enemy":
					//get the EnemyHealth script of that object
					EnemyHealth enemyHealth = hit.collider.GetComponentInParent <EnemyHealth> ();
					if(enemyHealth != null) //make sure it HAS an enemyHealth script
					{
						enemyHealth.damage(damage, target); //call it, passing in damage and direction of attack.
					}
					break;
                case "Level7Switch":
                    hit.transform.gameObject.GetComponent<Level7Switch>().run();
                    break;
			}

		}

	}
}