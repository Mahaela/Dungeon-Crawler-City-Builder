using UnityEngine;
using System.Collections;

public class GolemAttack : MonoBehaviour {

	public float attackSpeed = 2f;
	//public int damage = 10;

	public GameObject projectile;

	private GameObject player;
	private float timer;
	private bool playerInRange;
	
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		//health = player.GetComponent<CharacterHealth> (); //get player's health script
		timer = attackSpeed;
		playerInRange = false;
	}
	
	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.gameObject == player) //this means that it can attack player
		{
			playerInRange = true;
		}
	}
	
	
	void OnTriggerExit2D (Collider2D other)
	{
		if (other.gameObject == player) { //no longer in range
			playerInRange = false;
		}
	}
	// Update is called once per frame
	
	void FixedUpdate () {
		
		if (playerInRange && timer >= attackSpeed) {
			//direction of attack
			Vector3 direction = player.transform.position - gameObject.transform.position;
			//direction = direction.normalized;
			
			projectile.GetComponent<ArrowController>().direction = direction;
			GameObject firedArrow = (GameObject)Instantiate (projectile, transform.position, 
				new Quaternion(0,0,0,0));
			//firedArrow.GetComponent<ArrowController>().fire(direction, arrowSpeed, arrowTime);

			timer = 0f;
		} else if (timer < attackSpeed) { //just count the time
			timer += Time.deltaTime;
		}
	}
}
