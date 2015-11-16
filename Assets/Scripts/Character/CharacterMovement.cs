using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {


	Rigidbody player;
	Vector3 movement;
	public float speed = 250f;

	public float recoilForce = 50f;
	
	public float recoilTime = .3f;
	
	private float recoilTimer;
	
	bool recoil;
	// Use this for initialization
	void Start () {
		player = GetComponent<Rigidbody> ();
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

			float h = Input.GetAxisRaw ("Horizontal"); //raw is 0, 1, -1
			float v = Input.GetAxisRaw ("Vertical");
			
			Move (h, v);
		}
	}
	public void getHit(Vector3 direction)
	{
		if (!recoil) {
			player.AddForce (direction * recoilForce);
			recoil = true;
		}
	}
	void Move(float h, float v)
	{
		movement = new Vector3 (h, v, 0);
		movement = movement.normalized * speed * Time.deltaTime;
		//delta time is time between each update
		
		player.velocity = movement;
	}


}
