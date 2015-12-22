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

    public bool bossKey = false;
   
    /*=====================================================================
                  END OF LOCAL VARIABLE DECLARATIONS
    =====================================================================*/

    /*=====================================================================
                   BEGINNING OF EVENT DRIVEN FUNCTIONS
    =====================================================================*/

   
    /*=====================================================================
                      END OF EVENT DRIVEN FUNCTIONS
     =====================================================================*/

    /*=====================================================================
                   BEGINNING OF CUSTOM FUNCTIONS
    =====================================================================*/
    public void addKey() {

        keys++;
    }

    public bool hasKey() {

        if (keys > 0)
            return true;
        else
            return false;
    }

    public void removeKey(){
        if(keys > 0)
            keys--;
    }


    public void addBossKey()
    {
        bossKey = true;
    }

    public bool hasBossKey()
    {
        return bossKey;
    }
    /*=====================================================================
                   END OF CUSTOM FUNCTIONS
    =====================================================================*/

  
}
