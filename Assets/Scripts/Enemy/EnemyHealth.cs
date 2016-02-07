using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public int health = 30;
    //public MazeRoomController MazeRoom; //mazeroom that spawned the enemy
    public MonoBehaviour controller;

	double recoilTime; //time between taking damage, when it can't take more damage

	double damageTimer;
	EnemyMovement movement;
	bool recoil;
	// Use this for initialization
	void Start () {
		damageTimer = 0f;
		recoil = false;
		movement = GetComponent<EnemyMovement> (); 
		recoilTime = movement.recoilTime;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//if its in recoil state
		if (recoil) {
			damageTimer += Time.deltaTime; //count the time
			if(damageTimer >= recoilTime)
			{
				recoil = false;
				damageTimer = 0f;
			}
		}
	}
	//damage method to be called by sources of damage
	public void damage(int dmg, Vector3 direction)
	{
		if (!recoil) {
			health -= dmg; 
			recoil = true;
			movement.getHit(direction); //call it's movement script to resolve knockback
			Debug.Log("Enemy Health = " + health);
			checkDeath (); //have I died?
		}
	}

	void checkDeath()
	{
		if (health <= 0) {
            //MazeRoom.dead(); //notify mazeroom that I'm dead
            if (controller is MazeRoomController) {
                ((MazeRoomController)controller).dead();
            }
            else if (controller is OpenRoom) {
                ((OpenRoom)controller).dead();
            }
            Destroy(gameObject);	//I ded.	
		}
	}
}
