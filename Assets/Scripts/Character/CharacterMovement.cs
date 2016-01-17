using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {


<<<<<<< HEAD
	Rigidbody player;
	Vector3 movement;
	public float speed = 250f;

	public float recoilForce = 50f;
=======
	Rigidbody2D player;
	Vector3 movement;
	public float speed = 250f;

	public float recoilForce = 20f;
>>>>>>> 0d44d41a4309a62aadd74de9ab48779bb1551232
	
	public float recoilTime = .3f;
	
	private float recoilTimer;
	
	bool recoil;
	// Use this for initialization
	void Start () {
<<<<<<< HEAD
		player = GetComponent<Rigidbody> (); //yes
=======
		player = GetComponent<Rigidbody2D> (); //yes
>>>>>>> 0d44d41a4309a62aadd74de9ab48779bb1551232
	}
	
	// Update is called once per frame
	void FixedUpdate()
	{
		if (recoil) { //just count time, dont move
			recoilTimer += Time.deltaTime;
			if (recoilTimer >= recoilTime) {
				recoil = false;
				recoilTimer = 0f;
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
	public void getHit(Vector3 direction)
	{
		if (!recoil) {
			player.AddForce (direction * recoilForce); //take a force
			recoil = true;
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
