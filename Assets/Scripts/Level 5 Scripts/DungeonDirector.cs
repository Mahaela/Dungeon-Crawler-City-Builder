using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*========================================================================
 * Created by Carlos Chulo
 * @thecompscientist.dev@gmail.com
 * 
 * This script will attached to a collider that is child of the Level Manager.
 * 
 * When the collider is triggered, the doors specified will be shut,
 * and this script will spawn enemies within the colliders bounds before
 * it is destroyed.
 * 
 * When all enemies are destroyed then the doors will open, and this object
 * will be destroyed.
 * 
 ========================================================================*/
public class DungeonDirector : MonoBehaviour
{

    /*=====================================================================
                    LOCAL VARIABLE DECLARATIONS
    =====================================================================*/

    //store an array of doors that will be opened/closed.
    public Door[] doors;

    //store an array of enemies to spawn, note that not all my spawn
    public List<EnemyHealth> enemies;

    public List<GameObject> spawnedEnemies;

    //flag to check if this object is active or not
    public bool active = false;

    //int for maximum number of enemies to spawn, min is always 1
    public int maxSpawn = 3;

    /*=====================================================================
                  END OF LOCAL VARIABLE DECLARATIONS
    =====================================================================*/

    /*=====================================================================
                   BEGINNING OF EVENT DRIVEN FUNCTIONS
    =====================================================================*/


    /*=====================================================================
     * Name:            OnTriggerEnter2D
     * 
     * Description:     This function will be used to determine whether
     *                  the player has entered an "Encounter Zone", where
     *                  if they do, the DungeonDirector will spawn enemies
     *                  randomly selected from an array of enemy prefabs,
     *                  and randomly spawn them within that "Encounter Zone".
     *                  It also locks doors specified in a door array.
     *                  
     * Preconditions:   Collider2D other assumed to be the player's collider
    ====================================================================*/
    void OnTriggerEnter2D(Collider2D other)
    {

        //if the Encounter is not active...
        if (!active)
        {
            //we select how many enemies to spawn...
            int randomSpawn = Random.Range(1, maxSpawn);

            //we destroy the encounter zone collider...
            Destroy(this.gameObject.GetComponent<Collider2D>());

            //we lock the doors
            lockDoors();

            //we loop from 0 to randomSpawn, each iteration spawning one enemy...
            for (int i = 0; i < randomSpawn; i++)
            {
                //we select a location to spawn the enemy by unit Vector2...
                Vector2 randomPos = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));

                //we achieve this further by translating randomPos (* .5f for offset) to world coordinate
                randomPos = transform.TransformPoint(randomPos * .5f);

                //if enemies list is not empty...
                if (enemies.Count != 0)
                {
                    //we pick a random enemy from the list
                    int randomEnemy = Random.Range(0, enemies.Count - 1);

                    //and spawn it
                    Instantiate(enemies[randomEnemy], randomPos, transform.rotation); 
                }

                //we set this to be true
                active = true;
            }

            //After we spawn our enemies we want to be able to track them by getting a reference to them
            //we search for all Enemies in the world...
            GameObject[] EnemyArr = GameObject.FindGameObjectsWithTag("Enemy");

            //loop through this array of enemies...
            for (int i = 0; i < EnemyArr.Length; i++)
            {
                //we grab the clones...
                if (EnemyArr[i].name.Contains("(Clone)"))
                {
                    //add a ManagedSpawn script, and set its director to this script
                    EnemyArr[i].AddComponent<ManagedSpawn>().director = this;

                    //add this enemy to our list of spawnedEnemies
                    spawnedEnemies.Add(EnemyArr[i]);

                    //NOTE: This is the only way of getting reference to spawned objects. Instantiate returns a clone of
                    //whatever GameObject it spawns, but it is not a reference to the one active in the scene.
                }
            }

        }

    }

  
    /*=====================================================================
                      END OF EVENT DRIVEN FUNCTIONS
    =====================================================================*/

    /*=====================================================================
                   BEGINNING OF CUSTOM FUNCTIONS
    =====================================================================*/

    /*=====================================================================
     * Name:            updateSpawnCount
     * 
     * Description:     This function will be used to remove a defeated
     *                  enemy from the list of spawned enemies.
     *                  
     *                  If the list is empty at the end, we will unlock
     *                  the doors, and destroy this script/gameObject
     *                  
     * Preconditions:   GameObject Go assumed to be the GameObject pertaining
     *                  to an enemy we want to remove from the SpawnedEnemies
     *                  list
    ====================================================================*/
    public void updateSpawnCount(GameObject Go) {

        //remove the Go from spawnedEnemies
        spawnedEnemies.Remove(Go);

        //if the count of spawnedEnemies is 0, and we are active...
        if (spawnedEnemies.Count == 0 && active)
        {
            //set active to false
            active = false;

            //unlock the doors
            unlockDoors();

            //destroy this gameObject
            Destroy(gameObject);
        }
    }

    /*=====================================================================
     * Name:            lockDoors
     * 
     * Description:     This function will lock the doors specified
     *                  in the array of doors. Locking simply by setting
     *                  the door to active.
    ====================================================================*/
    void lockDoors()
    {
        //loop through doors array
        for (int i = 0; i < doors.Length; i++)
        {
            //set each door to active state
            doors[i].gameObject.SetActive(true);
        }
    }

    /*=====================================================================
     * Name:            unlockDoors
     * 
     * Description:     This function will unlock the doors specified
     *                  in the array of doors. Unlocking simply by setting
     *                  the door to inactive.
    ====================================================================*/
    void unlockDoors()
    {
        //loop through doors array
        for (int i = 0; i < doors.Length; i++)
        {
            //set each door to inactive state
            doors[i].gameObject.SetActive(false);
        }
    }

    /*=====================================================================
                   END OF CUSTOM FUNCTIONS
    =====================================================================*/
}
