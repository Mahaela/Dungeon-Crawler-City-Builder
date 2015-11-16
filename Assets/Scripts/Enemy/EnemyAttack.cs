using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

	public float attackSpeed = 2f;
	public int damage = 10;

	private GameObject player;
	private CharacterHealth health;
	private float timer;
	private bool playerInRange;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		health = player.GetComponent<CharacterHealth> ();
		timer = attackSpeed;
		playerInRange = false;
	}

	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject == player)
		{
			playerInRange = true;
		}
	}
	
	
	void OnTriggerExit (Collider other)
	{
		if (other.gameObject == player) {
			playerInRange = false;
		}
	}
	// Update is called once per frame

	void Update () {

		if (playerInRange && timer >= attackSpeed) {
			Vector3 direction = player.transform.position - gameObject.transform.position;
			direction = direction.normalized;
			health.Damage (damage, direction);
			timer = 0f;
		} else if (timer < attackSpeed) {
			timer += Time.deltaTime;
		}
	}
}
	