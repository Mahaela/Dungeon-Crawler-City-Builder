using UnityEngine;
using System.Collections;

public class OpenRoom : MonoBehaviour {

    public GameObject northRoom = null;
    public GameObject southRoom = null;
    public GameObject eastRoom = null;
    public GameObject westRoom = null;

	public GameObject[] enemies;
	private int enemyCount;
    private bool spawned = false;

	void Start () {
        enemyCount = enemies.Length;
	}
    
	public void dead()
	{
		enemyCount--;
		if (enemyCount == 0)
            openDoors();
	}

    public void openDoors()
    {
        if (northRoom != null)
            openNorthDoor();
        if (southRoom != null)
            openSouthDoor();
        if (eastRoom != null)
            openEastDoor();
        if (westRoom != null)
            openWestDoor();
    }

    public void openNorthDoor() {
        transform.Find("North Block").gameObject.SetActive(false);
        northRoom.transform.Find("South Block").gameObject.SetActive(false);
        northRoom.transform.Find("RoomShadow").GetComponent<MeshRenderer>().enabled = false;
    }

    public void openSouthDoor()
    {
        transform.Find("South Block").gameObject.SetActive(false);
        southRoom.transform.Find("North Block").gameObject.SetActive(false);
        southRoom.transform.Find("RoomShadow").GetComponent<MeshRenderer>().enabled = false;
    }

    public void openEastDoor()
    {
        transform.Find("East Block").gameObject.SetActive(false);
        eastRoom.transform.Find("West Block").gameObject.SetActive(false);
        eastRoom.transform.Find("RoomShadow").GetComponent<MeshRenderer>().enabled = false;
    }

    public void openWestDoor()
    {
        transform.Find("West Block").gameObject.SetActive(false);
        westRoom.transform.Find("East Block").gameObject.SetActive(false);
        westRoom.transform.Find("RoomShadow").GetComponent<MeshRenderer>().enabled = false;
    }

    public void spawn()
	{
        if (!spawned)
        {
            for (int i = 0; i < enemies.Length; i++) //loop through enemy array
            {
                //random location in the maze room 
                float x = Random.Range(-3f, 3f);
                float y = Random.Range(-3f, 3f);
                Vector3 spawnPoint = transform.position + new Vector3(x, y, 0);

                //set this enemy to enemy mazeroom to this one
                enemies[i].GetComponent<EnemyHealth>().controller = this;

                //make the enemy
                Instantiate(enemies[i], spawnPoint, Quaternion.identity);

            }
            spawned = true;
        }
	}

    public int getEnemyCount()
    {
        return enemyCount;
    }
}
