using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DungeonGameManager : MonoBehaviour {

    public GameObject inventory;
    bool displayInv = false;

    // Use this for initialization
    void Start () {
        Debug.Log("init inventory");
        List<int> temp = new List<int>();
        temp.Add(0);
        temp.Add(1);
        temp.Add(0);
        temp.Add(2);
        

        SaveLoad.Instance.SetInvArray(temp);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire2"))
        {
            Debug.Log("Toggling inventory");
            displayInv = !displayInv;
            inventory.SetActive(displayInv);
        }
    }
}
