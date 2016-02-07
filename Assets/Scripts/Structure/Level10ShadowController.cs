using UnityEngine;
using System.Collections;

public class Level10ShadowController : MonoBehaviour {

	private OpenRoom control;
	void Start () {
		//shadow ON
		control = this.transform.parent.GetComponent<OpenRoom> ();
		gameObject.SetActive (true);
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		//if player enters the shadow
		if(other.gameObject.tag == "Player")
		{
			gameObject.SetActive(false); //disable the shadow
			//init and spawn enemies
			control.spawn(); 
            if (control.getEnemyCount() == 0)
            {
                control.openDoors();
            }
		}
	}
}
