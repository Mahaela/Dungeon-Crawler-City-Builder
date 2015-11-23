using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {

    

	// Use this for initialization
	void Start () {
        SaveLoad.Instance.GetInvArray();
        Debug.Log("Generating Inventory");
        
        foreach (int i in SaveLoad.Instance.inventoryList)
        {
            GameObject temp = Instantiate(ItemTable.Instance.getItemAtIndex(i));
            temp.transform.SetParent(this.transform);
            Debug.Log(temp.GetComponent<Item>().itemName);

        }

    }

    void Awake()
    {
        
    }
	
	// Update is called once per frame
	void Update () {

        
	}
}
