using UnityEngine;
<<<<<<< HEAD
=======
using UnityEngine.UI;
>>>>>>> 0d44d41a4309a62aadd74de9ab48779bb1551232
using System.Collections;

public class CharacterHealth : MonoBehaviour {

	public int health = 100;
<<<<<<< HEAD

=======
	public Slider healthBar;
>>>>>>> 0d44d41a4309a62aadd74de9ab48779bb1551232
	double recoilTime;
	
	double damageTimer;
	CharacterMovement movement;
	bool recoil; //is it in post-damage immune state


	void Start () {
		damageTimer = 0f;
		recoil = false;
		movement = GetComponent<CharacterMovement> (); 
		recoilTime = 2 * movement.recoilTime;
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
	public void Damage(int dmg, Vector3 direction)
	{
		if (!recoil) {
			health -= dmg;
<<<<<<< HEAD
=======
			healthBar.value = health;
>>>>>>> 0d44d41a4309a62aadd74de9ab48779bb1551232
			recoil = true;
			movement.getHit(direction); //call player's movement script for knockback
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
