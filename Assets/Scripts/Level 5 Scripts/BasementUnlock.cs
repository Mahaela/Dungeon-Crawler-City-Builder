using UnityEngine;
using System.Collections;

/*========================================================================
 * Created by Carlos Chulo
 * @thecompscientist.dev@gmail.com
 * 
 * Simple script to unlock anything that may be hidden in the scene
 * 
 ========================================================================*/
public class BasementUnlock : MonoBehaviour {

    /*=====================================================================
                   BEGINNING OF EVENT DRIVEN FUNCTIONS
    =====================================================================*/

    /*=====================================================================
     * Name:        OnTriggerEnter2D
     * 
     * Description: We will use this function to detect when the player
     *              has flipped this switch. When they do, we will unhide
     *              the stairs.
     =====================================================================*/
    void OnTriggerEnter2D(Collider2D other)
    {
        //find the gameobject tagged unlock, enable the renderer and collider...
        GameObject.FindGameObjectWithTag("Unlock").GetComponent<Renderer>().enabled = true;
        GameObject.FindGameObjectWithTag("Unlock").GetComponent<Collider2D>().enabled = true;

        //... then destroy this script
        Destroy(this);
    }
    /*=====================================================================
                   BEGINNING OF EVENT DRIVEN FUNCTIONS
    =====================================================================*/
}
