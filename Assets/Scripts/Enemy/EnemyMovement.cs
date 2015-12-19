using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	Rigidbody2D enemy; 
	Vector3 movement;
	public float speed = 50f;
	public Rigidbody2D target;
	public float stopDistance = 10f; //distance where enemy stops moving
	public float recoilForce = 100f;
	public float moveRange = 6f;
	public float recoilTime = 1.5f;

	private float recoilTimer;

	bool recoil;
	private bool lockOn = false;
	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody2D> (); //find the character object
		enemy = GetComponent<Rigidbody2D> ();
		recoilTimer = 0;
		recoil = false;
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		//if you're getting knocked back
		if (recoil) {
			recoilTimer += Time.deltaTime; //add time
			if (recoilTimer >= recoilTime) { //check if still recoil
				recoil = false;
				recoilTimer = 0f;
			}
		} else { //you can move if no recoil
			//move towards character
			movement = (target.transform.position - enemy.transform.position);
			if (movement.magnitude < moveRange) { //but only if they're within range
				lockOn = true;
			}
			if (lockOn && Mathf.Abs (movement.magnitude) > stopDistance) { //check if its not within stopdistance
				Move ();
			} else {
				enemy.velocity = new Vector3 (0f, 0f, 0f);
			}
		}
	}
	//called by damage script
	public void getHit(Vector3 direction)
	{
		if (!recoil) {
			enemy.AddForce (direction * recoilForce); //toss character back
			recoil = true;
		}
	}

	void Move() //moves
	{
		movement = movement.normalized * speed * Time.deltaTime; //get unit vector in direction of movement, times speed and time

		//delta time is time between each update
		enemy.velocity = movement;

		//rotate

		//Quaternion newRotation = Quaternion.LookRotation(movement.normalized);
		//enemy.MoveRotation (newRotation);
	}

}
