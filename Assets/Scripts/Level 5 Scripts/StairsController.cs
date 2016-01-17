using UnityEngine;
using System.Collections;


/*========================================================================
 * Created by Carlos Chulo
 * @thecompscientist.dev@gmail.com
 * 
 * This script will be used to transport the player when
 * they decide to take the stairs.
 * 
 ========================================================================*/
public class StairsController : MonoBehaviour {

    /*=====================================================================
                    LOCAL VARIABLE DECLARATIONS
    =====================================================================*/

    //Reference to the GameObject representing the player
    GameObject player;

    //Reference to the target stairs
    public GameObject target;

    //Vector2 for the destination of the player
    public Vector2 targetLoc;

    /*=====================================================================
                   END OF LOCAL VARIABLE DECLARATIONS
    =====================================================================*/


    /*=====================================================================
                   BEGINNING OF EVENT DRIVEN FUNCTIONS
    =====================================================================*/


    /*=====================================================================
     * Name:            Start
     * 
     * Description:     We will use this function to initialize our Local
     *                  variables player, target, and targetLoc.
     *                  player will be set to point to our Player GameObject
     *                  target will be used to assign targetLoc a Vector2
     *                  value for the player's destination.
    =====================================================================*/
	void Start () {

        //find our player
        player = GameObject.FindGameObjectWithTag("Player");

        //if the target exists...
        if (target != null) {

            //we assign the targetLocation to be the target's up unit-vector (0,1,0) plus the targetPos (x,y,z) to be (x, y + 1, z)
            targetLoc = target.transform.up + target.transform.position;
        }
	}

    /*=====================================================================
     * Name:            Start
     * 
     * Description:     This function will fire when the player enters the
     *                  collider of this object, and will simply be
     *                  transported to the destination location.
    =====================================================================*/
    void OnTriggerEnter2D(Collider2D other)
    {
        //if our target has been assigned we teleport player to targetLoc
        if (target != null)
            player.GetComponent<Rigidbody2D>().position = targetLoc;
    }

    /*=====================================================================
                      END OF EVENT DRIVEN FUNCTIONS
     =====================================================================*/
}
