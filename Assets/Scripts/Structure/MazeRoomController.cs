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
	void Update () {
		
	}
	public void dead()
	{
		enemyCount--;

		if (enemyCount == 0) {
			for(int i = 0; i < wallsToCollapse.Length; i++)
			{
				wallsToCollapse[i].SetActive(false);
			}
			for( int i = 0; i < shadowsToFree.Length; i++)
			{
				shadowsToFree[i].GetComponent<MeshRenderer>().enabled = false;
			}
		}
	}
	public void spawn()
	{
		for(int i = 0; i < enemies.Length; i++)
		{
			float x = Random.Range(2f, 8f);
			float y = Random.Range(2f, 8f);
			Vector3 spawnPoint = transform.position + new Vector3(x, y, 0);
			enemies[i].GetComponent<EnemyHealth>().MazeRoom = this;

			Instantiate(enemies[i], spawnPoint, Quaternion.identity);

		}
	}
}
