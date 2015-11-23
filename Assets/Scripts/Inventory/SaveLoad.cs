using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SaveLoad : MonoBehaviour {

    public static SaveLoad Instance;
    private int[] inventoryArray;
    public List<int> inventoryList;


	// Use this for initialization
	void Awake () {
        Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetInvArray(List<int> saveList)
    {
        inventoryArray = saveList.ToArray();
        PlayerPrefsX.SetIntArray("Inv", inventoryArray);

    }

    public void GetInvArray()
    {
        inventoryArray = PlayerPrefsX.GetIntArray("Inv");
        inventoryList = inventoryArray.ToList();
        Debug.Log("saveload: inventory array get");
    }

    
}
