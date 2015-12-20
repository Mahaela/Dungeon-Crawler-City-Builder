using UnityEngine;
using System.Collections;

/*========================================================================
 * Created by Carlos Chulo
 * @thecompscientist.dev@gmail.com
 * 
 * This script will be used to add keys to the level manager.
 * 
 ========================================================================*/
public class Key : MonoBehaviour {

    /*=====================================================================
                    LOCAL VARIABLE DECLARATIONS
    =====================================================================*/
    LevelManager manager;

    /*=====================================================================
                  END OF LOCAL VARIABLE DECLARATIONS
    =====================================================================*/

    /*=====================================================================
                   BEGINNING OF EVENT DRIVEN FUNCTIONS
    =====================================================================*/
    void Start() {

        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<LevelManager>();
    }

    void OnTriggerEnter2D(Collider2D other) {

        if (other.gameObject.tag == "Player") {
            manager.addKey();
            Destroy(this.gameObject);
        }
    }


    /*=====================================================================
                      END OF EVENT DRIVEN FUNCTIONS
     =====================================================================*/

}
