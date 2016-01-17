using UnityEngine;
using System.Collections;

public class MazeRoomController : MonoBehaviour {


	public GameObject[] wallsToCollapse;
	public GameObject[] enemies;
	public GameObject[] shadowsToFree;
	private int enemyCount;
	// Use this for initialization
	void Start () {
		setEnemyCount ();
	}

	public void setEnemyCount()
	{
		enemyCount = enemies.Length;

	}
	// Update is called once per frame
	//void Update () {
		
	//}

	//called whenever an enemy created by this controller dies.
	public void dead()
	{
		enemyCount--;

		if (enemyCount == 0) {
			for(int i = 0; i < wallsToCollapse.Length; i++)
			{
				wallsToCollapse[i].SetActive(false); //disable all the walls to collapse
			}
			for( int i = 0; i < shadowsToFree.Length; i++)
			{
				shadowsToFree[i].GetComponent<MeshRenderer>().enabled = false; //free the shadows of the next room
			}
		}
	}

	//SPAWN THE ENEMIES GDAMMIT
	//but only when shadowController calls it
	public void spawn()
	{
        GameObject roomshadow = transform.Find("RoomShadow").gameObject;
        Vector3 min = roomshadow.GetComponent<Renderer>().bounds.min;
        Vector3 max = roomshadow.GetComponent<Renderer>().bounds.max;



        for (int i = 0; i < enemies.Length; i++) //loop through enemy array
		{

            //random location in the maze room 
            //float x = Random.Range(2f, 8f); 
            //float y = Random.Range(2f, 8f);
            //Vector3 spawnPoint = transform.position + new Vector3(x, y, 0);
            Vector3 spawnPoint = new Vector3(Random.Range(min.x,max.x),Random.Range(min.y,max.y),0);

			//set this enemy to enemy mazeroom to this one
			enemies[i].GetComponent<MazeEnemyHealth>().MazeRoom = this;

			//make the enemy
			Instantiate(enemies[i], spawnPoint, Quaternion.identity);

		}
	}
}
