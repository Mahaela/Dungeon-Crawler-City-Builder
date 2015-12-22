using UnityEngine;
using System.Collections;

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
     * Name:        Start
     * 
     * Description: This function will be used to store the reference
     *              of the scene's Level Manager into Local variable
     *              manager at spawn.
     ====================================================================*/
    void Start()
    {

        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<LevelManager>();
    }

    /*=====================================================================
     * Name:        OnTriggerEnter2D
     * 
     * Description: This function will be used to store the key the player
     *              collects into the level manager.
    ====================================================================*/
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            manager.addBossKey();
            Destroy(this.gameObject);
        }
    }


    /*=====================================================================
                      END OF EVENT DRIVEN FUNCTIONS
     =====================================================================*/
}
