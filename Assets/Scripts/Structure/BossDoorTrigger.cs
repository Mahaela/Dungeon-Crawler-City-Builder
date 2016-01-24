using UnityEngine;
using System.Collections;

public class BossDoorTrigger : MonoBehaviour {
    public GameObject player;
    public GameObject boss;
    public GameObject door;

    bool activated;

	// Use this for initialization
	void Start () {
        activated = false;
	}
	
	// Update is called once per frame
	void Update () {
	    if (boss == null) {
            door.SetActive(false);
            Destroy(gameObject);
        }
	}

    void OnTriggerEnter2D(Collider2D other) {
        if (boss != null && door != null && !activated && other.gameObject == player) {
            door.SetActive(true);
            activated = true;
        }
    }
}
