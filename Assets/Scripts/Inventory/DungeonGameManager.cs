using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DungeonGameManager : MonoBehaviour {

    public GameObject inventory;
    bool displayInv = false;

    // Use this for initialization
    void Start () {

        //setup level serializer
        LevelSerializer.PlayerName = "Test";
        Debug.Log("init inventory");

        //unused right now. used to set up the default inventory
        List<int> temp = new List<int>();
        temp.Add(0);
        temp.Add(1);
        temp.Add(0);
        temp.Add(2);
        temp.Add(3);
        temp.Add(1);
        temp.Add(4);
        temp.Add(3);
        temp.Add(5);
        temp.Add(3);
        temp.Add(4);
        temp.Add(6);

        //SaveLoad.Instance.SetInvArray(temp);
	}
	
	// Update is called once per frame
	void Update () {

        //jerry-rigged saving and loading the inventory
        if (Input.GetButtonDown("Fire2"))
        {
            Debug.Log("Toggling inventory");
            displayInv = !displayInv;
            inventory.SetActive(displayInv);
        }
        if (Input.GetButtonDown("QuickSave"))
        {
            Debug.Log("saving");
            LevelSerializer.SaveGame(LevelSerializer.PlayerName);
        }
        if (Input.GetButtonDown("QuickLoad"))
        {
            Debug.Log(LevelSerializer.PlayerName);
            Debug.Log("loading");
            LevelSerializer.SaveEntry sg = LevelSerializer.SavedGames[LevelSerializer.PlayerName][0];
            LevelSerializer.LoadNow(sg.Data);
            //inventory.GetComponent<Inventory>().HasChanged();
            Invoke("CallHasChanged", .1f);
        }
        //inventory.GetComponent<Inventory>().HasChanged();//somehow this helps loading the mods in each equipment
    }

    //delay the calling of haschanged so equip info is updated correctly.
    void CallHasChanged()
    {
        inventory.GetComponent<Inventory>().HasChanged();
    }
}
