using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {

    public GameObject[] wallsToCollapse;
    public GameObject[] shadowsToFree;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("pickup");
        if(other.gameObject.CompareTag ("Player"))
        {
            for (int i = 0; i < wallsToCollapse.Length; i++)
            {
                wallsToCollapse[i].SetActive(false);
            }
            for (int i = 0; i < shadowsToFree.Length; i++)
            {
                shadowsToFree[i].GetComponent<MeshRenderer>().enabled = false;
            }
        }
        gameObject.SetActive (false);
    }
}
