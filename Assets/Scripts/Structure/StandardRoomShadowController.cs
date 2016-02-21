using UnityEngine;

public class StandardRoomShadowController : MonoBehaviour {

	private StandardRoomController control;
	void Start () {
		//shadow ON
		control = transform.parent.GetComponent<StandardRoomController> ();
		gameObject.SetActive (true);
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		//if player enters the shadow
		if(other.gameObject.tag == "Player")
		{
			gameObject.SetActive(false); //disable the shadow
            //init and spawn enemies
            if (control != null) {
                control.setEnemyCount();
                control.spawn();
            }
		}
	}
}
