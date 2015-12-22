using UnityEngine;
using System.Collections;

public class BossDoor : MonoBehaviour {

    /*=====================================================================
                    LOCAL VARIABLE DECLARATIONS
    =====================================================================*/

    //store reference to our Level Manager
    LevelManager manager;


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
    void Start()
    {

        //store the reference of the level manager
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<LevelManager>();

        gameObject.GetComponent<Renderer>().material.color = Color.magenta;
  
    }


    /*====================================================================
     * Name:        Start
     * 
     * Description: We will use this event to detect when the player
     *              interacts with the door when a key is required.
     *              If the player (rather the manager) has a key, we
     *              will reduce the number of keys and open the door.
     ===================================================================*/
    void OnCollisionEnter2D(Collision2D other)
    {

        //if the manager is present, if the player has collided with this door, and a key is required...
        if (manager != null)
        {

            //and if the manager has a key...
            if (manager.hasBossKey())
            {

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
    public void unlockDoor()
    {

        this.gameObject.SetActive(false);

    }
    /*=====================================================================
                   END OF CUSTOM FUNCTIONS
    =====================================================================*/
}
