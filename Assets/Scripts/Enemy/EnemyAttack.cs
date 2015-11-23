using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

	/* this is attached to an outer collider child of the enemy, that is its attack range. 
	 * when character collides with this outer collider, it takes damage
	 */

	public float attackSpeed = 2f;
	public int damage = 10;

	private GameObject player;
	private CharacterHealth health;
	private float timer;
	private bool playerInRange;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		health = player.GetComponent<CharacterHealth> (); //get player's health script
		timer = attackSpeed;
		playerInRange = false;
	}

	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject == player) //this means that it can attack player
		{
			playerInRange = true;
		}
	}
	
	
	void OnTriggerExit (Collider other)
	{
		if (other.gameObject == player) { //no longer in range
			playerInRange = false;
		}
	}
	// Update is called once per frame

	void Update () {

		if (playerInRange && timer >= attackSpeed) {
			//direction of attack
			Vector3 direction = player.transform.position - gameObject.transform.position;
			direction = direction.normalized;

			//tell player health script to take damage
			health.Damage (damage, direction);
			timer = 0f;
		} else if (timer < attackSpeed) { //just count the time
			timer += Time.deltaTime;
		}
	}
}
	