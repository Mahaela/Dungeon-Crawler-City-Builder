using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class Inventory : MonoBehaviour, IHasChanged {
    [SerializeField] Transform slots; 
    

	// Use this for initialization
	void Start () {
        HasChanged();
        SaveLoad.Instance.GetInvArray();
        Debug.Log("Generating Inventory");

        int count = 0;
        foreach (int i in SaveLoad.Instance.inventoryList)
        {
            GameObject temp = Instantiate(ItemTable.Instance.getItemAtIndex(i));
            Transform slot = transform.GetChild(0).transform.GetChild(count);
            temp.transform.SetParent(slot);
            Debug.Log(temp.GetComponent<Item>().itemName);
            count++;
        }

    }

    void Awake()
    {
        
    }
	
	// Update is called once per frame
	void Update () {

        
	}

    public void HasChanged()
    {
        foreach(Transform slotTransform in slots)
        {

        }
    }
}

namespace UnityEngine.EventSystems
{
    public interface IHasChanged : IEventSystemHandler
    {
        void HasChanged();
    }
}