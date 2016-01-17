using UnityEngine;
using System.Collections;

/*========================================================================
 * Created by Carlos Chulo
 * @thecompscientist.dev@gmail.com
 * 
 * Simple script to unlock anything that interacts with the GameObject
 * with this script attached.
 * 
 ========================================================================*/
public class Switch : MonoBehaviour {

    /*=====================================================================
                    LOCAL VARIABLE DECLARATIONS
    =====================================================================*/

    //store the state of this button
    public bool pressed = false;


    public Door target;
    /*=====================================================================
                   END OF  LOCAL VARIABLE DECLARATIONS
    =====================================================================*/

    /*=====================================================================
               BEGINNING OF EVENT DRIVEN FUNCTIONS
    =====================================================================*/

    /*=====================================================================
     * Name:        Start
     * 
     * Description: We will use this function to change the switch's color
     *              to reflect is state
     ====================================================================*/
    void Start()
    {
        GetComponent<Renderer>().material.color = Color.cyan;
    }

    /*=====================================================================
    * Name:        OnTriggerEnter2D
    * 
    * Description: We will use this function to detect when the player
     *             has pressed it. We will change the switch color to
     *             reflect this state.
    ====================================================================*/
    void OnTriggerEnter2D(Collider2D other) {
        pressed = true;
        GetComponent<Renderer>().material.color = Color.grey;

        if (target != null)
            target.gameObject.SetActive(false);
    }

    /*=====================================================================
                      END OF EVENT DRIVEN FUNCTIONS
     =====================================================================*/
}
