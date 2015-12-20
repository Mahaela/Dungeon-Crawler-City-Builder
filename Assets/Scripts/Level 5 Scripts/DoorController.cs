using UnityEngine;
using System.Collections;


/*========================================================================
 * Created by Carlos Chulo
 * @thecompscientist.dev@gmail.com
 * 
 * This script will be used to handle unlocking of doors with keys.
 * 
 ========================================================================*/
public class DoorController : MonoBehaviour {

    /*=====================================================================
                    LOCAL VARIABLE DECLARATIONS
    =====================================================================*/

    LevelManager manager;

    public enum EdoorReq
    {
        keyRequired,
        killRequired,
        switchRequired,
        noReq
    }

    public EdoorReq requirement;


    /*=====================================================================
                  END OF LOCAL VARIABLE DECLARATIONS
   =====================================================================*/

    /*=====================================================================
                   BEGINNING OF EVENT DRIVEN FUNCTIONS
    =====================================================================*/

    void Awake() {

    }

	// Use this for initialization
	void Start () {

        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<LevelManager>();

        if (requirement == EdoorReq.keyRequired)
            gameObject.GetComponent<Renderer>().material.color= Color.yellow;
        else if(requirement == EdoorReq.killRequired)
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        else if (requirement == EdoorReq.switchRequired)
            gameObject.GetComponent<Renderer>().material.color = Color.blue;
        else
            gameObject.GetComponent<Renderer>().material.color = Color.green;
	}
	
	

    void OnCollisionEnter2D (Collision2D other) {

        if (manager != null && other.gameObject.tag == "Player" && requirement == EdoorReq.keyRequired) {
            if (manager.hasKey()){
                manager.removeKey();
                unlockDoor();
            }
        }
    }

    /*=====================================================================
                      END OF EVENT DRIVEN FUNCTIONS
     =====================================================================*/

    void unlockDoor() {
        Destroy(this.gameObject);
    }

}
