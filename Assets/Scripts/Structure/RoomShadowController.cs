using UnityEngine;
using System.Collections;

public class RoomShadowController : MonoBehaviour {

	private MazeRoomController control;
	void Start () {
		control = this.transform.parent.GetComponent<MazeRoomController> ();
		gameObject.SetActive (true);
	}

	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			gameObject.SetActive(false);
			control.setEnemyCount();
			control.spawn();
		}
	}
}
