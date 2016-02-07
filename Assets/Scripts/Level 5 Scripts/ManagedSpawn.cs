using UnityEngine;
using System.Collections;

/*========================================================================
 * Created by Carlos Chulo
 * @thecompscientist.dev@gmail.com
 * 
 * This script will be a simple script to track how many enemies were spawned
 * by the DungeonDirector
 * 
 ========================================================================*/
public class ManagedSpawn : MonoBehaviour {

    /*=====================================================================
                    LOCAL VARIABLE DECLARATIONS
    =====================================================================*/

    //store a reference to the Dungeon Director
    public DungeonDirector director;

    /*=====================================================================
                  END OF LOCAL VARIABLE DECLARATIONS
    =====================================================================*/

    /*=====================================================================
                   BEGINNING OF EVENT DRIVEN FUNCTIONS
    =====================================================================*/

    /*=====================================================================
     * Name:            OnDestroy
     * 
     * Description:     This function will be used to update the
     *                  EnemiesSpawnCount list in DungeonDirector
    ====================================================================*/
    void OnDestroy()
    {
        director.updateSpawnCount(this.gameObject);
    }

    /*=====================================================================
                      END OF EVENT DRIVEN FUNCTIONS
     =====================================================================*/
}
