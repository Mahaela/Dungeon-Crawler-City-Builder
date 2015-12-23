using UnityEngine;
using System.Collections;


/*========================================================================
 * Created by Carlos Chulo
 * @thecompscientist.dev@gmail.com
 * 
 * This script will be used to handle the logic of the boss door.
 * 
 * When the player collides with the door it will check to see if
 * the player has obtained the boss key
 ========================================================================*/
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
     * Name:            Start
     * 
     * Description:     we will use this to initialize our variables, as well
     *                  as set the look of the door for debugging purposes.
     ====================================================================*/
    void Start()
    {

        //store the reference of the level manager
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<LevelManager>();
        
        //set the color of the boss door
        gameObject.GetComponent<Renderer>().material.color = Color.magenta;
  
    }


    /*====================================================================
     * Name:            OnCollisionEnter2D
     * 
     * Description:     We will use this event to detect when the player
     *                  interacts with the door when a key is required.
     *                  If the player (rather the manager) has a key, we
     *                  will reduce the number of keys and open the door.
     *              
     * Pre-Conditions:  Collision2D other assumed to be the player collider
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
     * Description: this function opens the door by setting it to inactive
     ===================================================================*/
    public void unlockDoor()
    {

        this.gameObject.SetActive(false);

    }
    /*=====================================================================
                   END OF CUSTOM FUNCTIONS
    =====================================================================*/
}
