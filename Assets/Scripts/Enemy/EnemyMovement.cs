using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	Rigidbody2D enemy; 
	Vector3 movement;
	public float speed = 50f;
	public Rigidbody2D target;
	public float stopDistance = 10f; //distance where enemy stops moving
	//public float recoilForce = 100f;
	public float moveRange = 6f;
	public float knockbackDistance = 75f;
	public float stunTime = 1.5f;
	public float knockbackSpeed = 1000f;

	private Vector3 knockDirection;
	private float distToGo;
	private float stunTimer;

	bool recoil;
	private bool lockOn = false;
	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody2D> (); //find the character object

		enemy = GetComponent<Rigidbody2D> ();
		distToGo = 0;
		stunTimer = 0;
		recoil = false;
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		//if you're getting knocked back
		if (recoil) {
			stunTimer -= Time.deltaTime;
			if (distToGo > 0) {
				enemy.velocity = knockDirection.normalized * knockbackSpeed * Time.deltaTime;
				distToGo -= knockbackSpeed * Time.deltaTime;
				Debug.Log (distToGo);
			} else if (stunTimer <= 0f) {
				recoil = false;
				stunTimer = 0f;
			} else {
				enemy.velocity = new Vector3 (0f, 0f, 0f);
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
			knockDirection = direction;
			stunTimer = stunTime;
			distToGo = knockbackDistance;
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
