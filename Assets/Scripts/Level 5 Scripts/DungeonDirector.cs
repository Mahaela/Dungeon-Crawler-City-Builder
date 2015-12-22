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

    //store an array of doors that will be opened/closed.
    public Door[] doors;

    //store an array of enemies to spawn, note that not all my spawn
    public List<EnemyHealth> enemies;

    public List<GameObject> spawnedEnemies;

    //flag to check if this object is active or not
    public bool active = false;

    //int for maximum number of enemies to spawn, min is always 1
    public int maxSpawn = 3;

    //a private Vector2 variable the center point of this objects collider
    private Vector2 centerPoint;

    //a private Vector2 to store the size of this collider
    private Vector2 size;

    //store reference to BoxCollider2D of this object, if it exists
    private BoxCollider2D collider;

    //store bounds of this objects collider
    private float top;
    private float bottom;
    private float left;

    /*=====================================================================
                   BEGINNING OF EVENT DRIVEN FUNCTIONS
    =====================================================================*/

    void Awake()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (!active)
        {
            int randomSpawn = Random.Range(1, maxSpawn);


            Destroy(this.gameObject.GetComponent<Collider2D>());

            lockDoors();

            for (int i = 0; i < randomSpawn; i++)
            {
                Vector2 randomPos = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
                randomPos = transform.TransformPoint(randomPos * .5f);

                if (enemies.Count != 0)
                {
                    int randomEnemy = Random.Range(0, enemies.Count - 1);
                    Instantiate(enemies[randomEnemy], randomPos, transform.rotation); 
                }
                active = true;
            }

            GameObject[] EnemyArr = GameObject.FindGameObjectsWithTag("Enemy");
            for (int i = 0; i < EnemyArr.Length; i++)
            {
                if (EnemyArr[i].name.Contains("(Clone)"))
                {
                    EnemyArr[i].AddComponent<ManagedSpawn>().director = this;
                    spawnedEnemies.Add(EnemyArr[i]);
                }
            }

        }

    }

    // Update is called once per frame
    void Update()
    {

        if (active && spawnedEnemies.Count == 0)
        {
            active = false;
            unlockDoors();
            Destroy(gameObject);
        }
    }

    /*=====================================================================
                      END OF EVENT DRIVEN FUNCTIONS
    =====================================================================*/

    /*=====================================================================
                   BEGINNING OF CUSTOM FUNCTIONS
    =====================================================================*/

    void lockDoors()
    {
        for (int i = 0; i < doors.Length; i++)
        {
            doors[i].gameObject.SetActive(true);
        }
    }

    void unlockDoors()
    {
        for (int i = 0; i < doors.Length; i++)
        {
            doors[i].gameObject.SetActive(false);
        }
    }

    /*=====================================================================
                   END OF CUSTOM FUNCTIONS
    =====================================================================*/
}
