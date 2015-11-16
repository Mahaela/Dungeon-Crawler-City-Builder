using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public int health = 30;
	public MazeRoomController MazeRoom;

	double recoilTime;

	double damageTimer;
	EnemyMovement movement;
	bool recoil;
	// Use this for initialization
	void Start () {
		damageTimer = 0f;
		recoil = false;
		movement = GetComponent<EnemyMovement> (); 
		recoilTime = 2 * movement.recoilTime;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (recoil) {
			damageTimer += Time.deltaTime;
			if(damageTimer >= recoilTime)
			{
				recoil = false;
				damageTimer = 0f;
			}
		}
	}
	public void damage(int dmg, Vector3 direction)
	{
		if (!recoil) {
			health -= dmg;
			recoil = true;
			movement.getHit(direction);
			Debug.Log("Enemy Health = " + health);
			checkDeath ();
		}
	}

	void checkDeath()
	{
		if (health <= 0) {
			MazeRoom.dead();
			Destroy(gameObject);		
		}
	}
}
