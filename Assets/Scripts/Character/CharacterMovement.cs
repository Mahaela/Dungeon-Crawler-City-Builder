using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {


	Rigidbody2D player;
	Vector3 movement;
	public float speed = 250f;

	public int recoilResist = 0;
	
	public float knockbackSpeed = 1000f;

	private Vector3 knockDirection;
	private float stunTimer;
	private float distToGo;
	bool recoil;
	CharacterAttack attack;
	// Use this for initialization
	void Start () {
		player = GetComponent<Rigidbody2D> (); //yes
		attack = GetComponent<CharacterAttack>();
	}
	
	// Update is called once per frame
	void FixedUpdate()
	{
		
		if (recoil) { //just count time, dont move
			stunTimer -= Time.deltaTime;
			if (distToGo > 0) {
				player.velocity = knockDirection.normalized * knockbackSpeed * Time.deltaTime;
				distToGo -= knockbackSpeed * Time.deltaTime;
			} else if (stunTimer <= 0f) {
				recoil = false;
				stunTimer = 0f;
			} else {
				player.velocity = new Vector3 (0f, 0f, 0f);
			}
		} else {
			//actually move
			//this gets 1, 0, -1 for horizontal and vertical direction
			float h = Input.GetAxisRaw ("Horizontal"); //raw is 0, 1, -1
			float v = Input.GetAxisRaw ("Vertical");

			//MOVE MOVE MOVE
			Move (h, v);
		}
	}
	//called if you're hit
	public void getHit(Vector3 direction, int recoilDist, float stunTime)
	{
		if (!recoil) {
			knockDirection = direction;
			distToGo += recoilDist; //knockback this distance
			stunTimer = stunTime;
			recoil = true;

			attack.stun (stunTime);
		}
	}

	void Move(float h, float v) 
	{
		//direction
		movement = new Vector3 (h, v, 0);
		//move in that direction with distance = speed * time
		movement = movement.normalized * speed * Time.deltaTime;
		//delta time is time between each update
		player.velocity = movement;
	}
}
