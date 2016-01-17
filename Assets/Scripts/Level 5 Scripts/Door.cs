using UnityEngine;
using System.Collections;


/*========================================================================
 * Created by Carlos Chulo
 * @thecompscientist.dev@gmail.com
 * 
 * This script will be used to handle unlocking of doors with keys.
 * 
 ========================================================================*/
public class Door : MonoBehaviour {

    /*=====================================================================
                    LOCAL VARIABLE DECLARATIONS
    =====================================================================*/

    //store reference to our Level Manager
    LevelManager manager;

    //make an enum to store requirements for door to unlock
    //NOTE: Enum is currently set up for debugging purposes. (Color coding)
    public enum EdoorReq
    {
        keyRequired,
        killRequired,
        switchRequired,
        noReq
    }

    //store a state requirement for this door to unlock
    public EdoorReq requirement;


    /*=====================================================================
                  END OF LOCAL VARIABLE DECLARATIONS
   =====================================================================*/

    /*=====================================================================
                   BEGINNING OF EVENT DRIVEN FUNCTIONS
    =====================================================================*/

	/*=====================================================================
     * Name:        Start
     * 
     * Description: we will use this to initialize our variables, as well
     *              as set the look of the door for debugging purposes.
     ====================================================================*/
	void Start () {

        //store the reference of the level manager
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<LevelManager>();

        //set the color of the door depending on its unlock requirement:
        //yellow = key required
        //red = kill required
        //blue = switch required
        //green = no requirement
        if (requirement == EdoorReq.keyRequired)
            gameObject.GetComponent<Renderer>().material.color= Color.yellow;
        else if(requirement == EdoorReq.killRequired)
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        else if (requirement == EdoorReq.switchRequired)
            gameObject.GetComponent<Renderer>().material.color = Color.blue;
        else
            gameObject.GetComponent<Renderer>().material.color = Color.green;
	}
	
	
    /*====================================================================
     * Name:        Start
     * 
     * Description: We will use this event to detect when the player
     *              interacts with the door when a key is required.
     *              If the player (rather the manager) has a key, we
     *              will reduce the number of keys and open the door.
     ===================================================================*/
    void OnCollisionEnter2D (Collision2D other) {

        //if the manager is present, if the player has collided with this door, and a key is required...
        if (manager != null && other.gameObject.tag == "Player" && requirement == EdoorReq.keyRequired) {

            //and if the manager has a key...
            if (manager.hasKey()){

                //remove the key...
                manager.removeKey();

                //unlock the door
                unlockDoor();
            }
        }
    }

    /*=====================================================================
                      END OF EVENT DRIVEN FUNCTIONS
     =====================================================================*/

    /*=====================================================================
                   BEGINNING OF CUSTOM FUNCTIONS
    =====================================================================*/

    /*====================================================================
     * Name:        unlockDoor
     * 
     * Description: this function destroys this door (it opens)
     ===================================================================*/
    public void unlockDoor() {

        this.gameObject.SetActive(false);

    }
    /*=====================================================================
                   END OF CUSTOM FUNCTIONS
    =====================================================================*/

}
