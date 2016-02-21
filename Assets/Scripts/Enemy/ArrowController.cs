using UnityEngine;
using System.Collections;

public class ArrowController : MonoBehaviour {

	// Use this for initialization
	GameObject player;
	Rigidbody2D body;
	float timer = 0;
	public Vector3 direction = new Vector3(0, 0);
	public float arrowSpeed =  10000f;
	public float arrowTime = 100;

	public int damage = 10;
	public int knockbackDist = 2;
	public float stunTime = .5f;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		body = GetComponent<Rigidbody2D> ();
		direction = player.transform.position - transform.position;
		timer = 2f;
		transform.rotation = new Quaternion (0, 0, 0, 0);
	}
	void Start () {
		
		fire (direction, arrowSpeed, arrowTime);
	}
	void OnTriggerEnter2D (Collider2D other)
	{

		if (other.gameObject == player) {
			collide ();
		}
	}

	void collide()
	{
		player.GetComponent<CharacterHealth> ().Damage (damage, direction, knockbackDist, stunTime);
		Destroy (this.gameObject);
	}
	
	public void fire (Vector3 v, float speed, float time)
	{
		v.z = 0;

		body.velocity = v.normalized * speed * Time.deltaTime;
		v.z = 0;

		transform.rotation = Quaternion.LookRotation(new Vector3(0,0,1), v.normalized);
		timer += time;
	}
	void FixedUpdate () {
		
		if (timer > 0) {
			
			timer -= Time.deltaTime;
		}
		else if(timer < 0)
		{
			
			this.enabled = false;
			Destroy(this.gameObject);
		}

	}
}
