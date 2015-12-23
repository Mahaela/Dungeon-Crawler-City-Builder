using UnityEngine;
using System.Collections;

/*========================================================================
 * Created by Carlos Chulo
 * @thecompscientist.dev@gmail.com
 * 
 * This script will be used to handle the logic of the boss key.
 * 
 * When the player collides with the door it will check to see if
 * the player has obtained the boss key
 * 
 ========================================================================*/
public class BossKey : MonoBehaviour {

    /*=====================================================================
                    LOCAL VARIABLE DECLARATIONS
    =====================================================================*/

    //store a reference to the manager
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
     * Description:     This function will be used to store the reference
     *                  of the scene's Level Manager into Local variable
     *                  manager at spawn.
     ====================================================================*/
    void Start()
    {

        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<LevelManager>();
    }

    /*=====================================================================
     * Name:            OnTriggerEnter2D
     * 
     * Description:     This function will be used to store the key the player
     *                  collects into the level manager.
     *                  
     * Preconditions:   Collider2D other assumed to be the player's collider
    ====================================================================*/
    void OnTriggerEnter2D(Collider2D other)
    {

        //check to see if the collider is the player
        if (other.gameObject.tag == "Player")
        {
            //we add the boss key to the manager
            manager.addBossKey();

            //destroy this key
            Destroy(this.gameObject);
        }
    }


    /*=====================================================================
                      END OF EVENT DRIVEN FUNCTIONS
     =====================================================================*/
}
