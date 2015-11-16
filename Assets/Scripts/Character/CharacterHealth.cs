using UnityEngine;
using System.Collections;

public class CharacterHealth : MonoBehaviour {

	public int health = 100;

	double recoilTime;
	
	double damageTimer;
	CharacterMovement movement;
	bool recoil;
	// Use this for initialization
	void Start () {
		damageTimer = 0f;
		recoil = false;
		movement = GetComponent<CharacterMovement> (); 
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
	public void Damage(int dmg, Vector3 direction)
	{
		if (!recoil) {
			health -= dmg;
			recoil = true;
			movement.getHit(direction);
			Debug.Log("Character Health = " + health);
			checkDeath ();
		}
	}
	
	void checkDeath()
	{
		if (health <= 0) {
			Destroy(gameObject);		
		}
	}
}
