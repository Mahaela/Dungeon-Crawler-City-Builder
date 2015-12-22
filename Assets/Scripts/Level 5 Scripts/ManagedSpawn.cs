using UnityEngine;
using System.Collections;

public class ManagedSpawn : MonoBehaviour {

    public DungeonDirector director;

    void OnDestroy()
    {
        director.spawnedEnemies.Remove(this.gameObject);
    }
}
