using UnityEngine;
using System.Collections;

public class ItemTable : MonoBehaviour {

    public static ItemTable Instance;
    public GameObject[] table;

	// Use this for initialization
	void Awake () {
        Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public GameObject getItemAtIndex(int index)
    {
        return table[index];
    }
}
