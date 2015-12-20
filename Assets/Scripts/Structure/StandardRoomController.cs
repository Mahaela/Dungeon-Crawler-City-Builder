using UnityEngine;

public class StandardRoomController : MonoBehaviour {

	public GameObject[] enemies;
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
	}

	//SPAWN THE ENEMIES GDAMMIT
	//but only when shadowController calls it
	public void spawn()
	{
		for(int i = 0; i < enemies.Length; i++) //loop through enemy array
		{
			//random location in the maze room 
			float x = Random.Range(2f, 8f); 
			float y = Random.Range(2f, 8f);
			Vector3 spawnPoint = transform.position + new Vector3(x, y, 0);

			//make the enemy
			Instantiate(enemies[i], spawnPoint, Quaternion.identity);

		}
	}
}
