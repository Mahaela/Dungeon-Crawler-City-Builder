using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharacterHealth : MonoBehaviour {

	public int health = 100;
	public Slider healthBar;
	public double recoilTime = 2f;
	
	double damageTimer;
	CharacterMovement movement;
	bool recoil; //is it in post-damage immune state


	void Start () {
		damageTimer = 0f;
		recoil = false;
		movement = GetComponent<CharacterMovement> (); 
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (recoil) { //dont take damage, just count time
			damageTimer += Time.deltaTime;
			if(damageTimer >= recoilTime)
			{
				recoil = false;
				damageTimer = 0f;
			}
		}
	}
	public void Damage(int dmg, Vector3 direction, int recoilDist, float stunTime)
	{
		if (!recoil) {
			health -= dmg;
			healthBar.value = health;
			recoil = true;
			movement.getHit(direction, recoilDist, stunTime); //call player's movement script for knockback
			Debug.Log("Character Health = " + health);
			checkDeath (); //has I died
		}
	}
	
	void checkDeath()
	{
		if (health <= 0) {
			Destroy(gameObject);	//game breaks	
		}
	}
}
