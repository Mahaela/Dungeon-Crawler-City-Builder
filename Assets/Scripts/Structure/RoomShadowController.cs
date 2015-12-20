using UnityEngine;
using System.Collections;

public class RoomShadowController : MonoBehaviour {

	private MazeRoomController control;
	void Start () {
		//shadow ON
		control = this.transform.parent.GetComponent<MazeRoomController> ();
		gameObject.SetActive (true);
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		//if player enters the shadow
		if(other.gameObject.tag == "Player")
		{
			gameObject.SetActive(false); //disable the shadow
			//init and spawn enemies
			control.setEnemyCount();
			control.spawn(); 
		}
	}
}
