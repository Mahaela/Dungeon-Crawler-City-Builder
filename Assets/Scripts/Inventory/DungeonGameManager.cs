using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DungeonGameManager : MonoBehaviour {

    public GameObject inventory;
    bool displayInv = false;

    // Use this for initialization
    void Start () {
        LevelSerializer.PlayerName = "Test";
        Debug.Log("init inventory");
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
        }
    }
}
