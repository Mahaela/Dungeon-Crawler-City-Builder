using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	Rigidbody enemy;
	Vector3 movement;
	public float speed = 50f;
	public Rigidbody target;
	public float stopDistance;
	public float recoilForce = 100f;

	public float recoilTime = 1.5f;

	private float recoilTimer;

	bool recoil;
	private bool lockOn = false;
	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody> ();
		enemy = GetComponent<Rigidbody> ();
		stopDistance = 1f;
		recoilTimer = 0;
		recoil = false;
	}
	
	// Update is called once per frame
	void FixedUpdate()
	{
		if (recoil) {
			recoilTimer += Time.deltaTime;
			if (recoilTimer >= recoilTime) {
				recoil = false;
				recoilTimer = 0f;
			}
		} else {

			movement = (target.transform.position - enemy.transform.position);
			if (movement.magnitude < 6f) {
				lockOn = true;
			}
			if (lockOn && Mathf.Abs (movement.magnitude) > stopDistance) {
				Move ();
			} else {
				enemy.velocity = new Vector3 (0f, 0f, 0f);
			}
		}
	}

	public void getHit(Vector3 direction)
	{
		if (!recoil) {
			enemy.AddForce (direction * recoilForce);
			recoil = true;
		}
	}
	void Move()
	{
		movement = movement.normalized * speed * Time.deltaTime;
		//delta time is time between each update
		enemy.velocity = movement;
	}

}
