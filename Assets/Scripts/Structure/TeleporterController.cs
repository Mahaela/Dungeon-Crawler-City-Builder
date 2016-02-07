using UnityEngine;
using System.Collections;

public class TeleporterController : MonoBehaviour {

	Rigidbody2D player; //Rigidbody of the player 
	public GameObject target; //target teleporter
	public bool on = true;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody2D> ();
	}
	void OnTriggerEnter2D (Collider2D other)
	{
		//if player enters the shadow
		if (on && other.gameObject.tag == "Player") {
			target.GetComponent<TeleporterController>().setEnabled(false);
			player.position = target.transform.position;
		}
	}
	void OnTriggerExit2D (Collider2D other)
	{
		on = true;
	}

	public void setEnabled(bool b)
	{
		on = b;
	}
	// Update is called once per frame
}
