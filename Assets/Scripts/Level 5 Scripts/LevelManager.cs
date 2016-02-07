using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*========================================================================
 * Created by Carlos Chulo
 * @thecompscientist.dev@gmail.com
 * 
 * This script will be used to keep track of the progress in the level.
 * 
 * We will store how many keys the player has collected, and the
 * status of any enemies that must be defeated for any types of unlocks
 * such as doors opening, chests appearing, keys being granted, etc.
 * 
 ========================================================================*/
public class LevelManager : MonoBehaviour {

    /*=====================================================================
                    LOCAL VARIABLE DECLARATIONS
    =====================================================================*/

    //count how many keys we have
    public int keys = 0;

    //flag to check if the player has found the bossKey or not
    public bool bossKey = false;
   
    /*=====================================================================
                  END OF LOCAL VARIABLE DECLARATIONS
    =====================================================================*/

    /*=====================================================================
                   BEGINNING OF CUSTOM FUNCTIONS
    =====================================================================*/

    /*=====================================================================
     * Name:        addKey
     * 
     * Description: This function will be used to add a key to the player's
     *              key count.
     ====================================================================*/
    public void addKey() {

        keys++;
    }

    /*=====================================================================
     * Name:            hasKey
     * 
     * Description:     This function will be used to check if the player
     *                  has keys.
     *              
     * Post-Conditions: Return true if the player has at least one key
     *                  Return false otherwise
     ====================================================================*/
    public bool hasKey() {

        if (keys > 0)
            return true;
        else
            return false;
    }

    /*=====================================================================
     * Name:            removeKey
     * 
     * Description:     This function will remove a key from the player's
     *                  inventory, granted they have keys to be removed.
     ====================================================================*/
    public void removeKey(){
        if(keys > 0)
            keys--;
    }

    /*=====================================================================
     * Name:            addBossKey
     * 
     * Description:     This function will add bossKey by setting the
     *                  flag to true.
     ====================================================================*/
    public void addBossKey()
    {
        bossKey = true;
    }

    /*=====================================================================
     * Name:            removeKey
     * 
     * Description:     This function will check if the player has found
     *                  the bossKey
     * 
     * Post-Conditions: Returns the state of bossKey
     ====================================================================*/
    public bool hasBossKey()
    {
        return bossKey;
    }
    /*=====================================================================
                   END OF CUSTOM FUNCTIONS
    =====================================================================*/

  
}
