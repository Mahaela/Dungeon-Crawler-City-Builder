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

    //list of type DoorData to store, see nested class DoorData
    public List<DoorData> data;
    /*=====================================================================
                  END OF LOCAL VARIABLE DECLARATIONS
    =====================================================================*/

    /*=====================================================================
                   BEGINNING OF EVENT DRIVEN FUNCTIONS
    =====================================================================*/

    void Update()
    {
        updateDoorData();
    }
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

    public void updateDoorData()
    {
        for (int i = 0; i < data.Count; i++)
        {
            if (data[i].door.requirement == Door.EdoorReq.killRequired)
            {
                if (data[i].enemy == null)
                {
                    data[i].door.unlockDoor();
                    data.RemoveAt(i);
                }
            }
            else if (data[i].door.requirement == Door.EdoorReq.switchRequired)
            {
                if (data[i].goSwitch != null)
                {
                    if (data[i].goSwitch.pressed)
                    {
                        data[i].door.unlockDoor();
                        data.RemoveAt(i);
                    }
                }
                else
                {
                    Debug.LogError("Doors marked as switch required must be assigned a switch");
                }
            }
        }

           
    }
    /*=====================================================================
                   END OF CUSTOM FUNCTIONS
    =====================================================================*/

    [System.Serializable]
    public class DoorData : System.Object {
        public Door door;

        public EnemyHealth enemy;

        public Switch goSwitch;
    }
}
