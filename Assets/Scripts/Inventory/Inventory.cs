using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class Inventory : MonoBehaviour, IHasChanged {
    [SerializeField] Transform slots; 
    [SerializeField] Text invText;
    

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
        int totalDef = 0;
        int totalAtk = 0;
        int totalDodge = 0;
        System.Text.StringBuilder builder = new System.Text.StringBuilder();
        builder.Append("Current Equipment: ");
        foreach (Transform slotTransform in slots)
        {
            GameObject item = slotTransform.GetComponent<Slot>().item;
            if(item)
            {
                builder.Append(item.GetComponent<Item>().itemName);
                builder.Append(" - ");
                if(item.GetComponent<Item>() is Armor)
                {
                    totalDef += item.GetComponent<Armor>().defense;
                    totalDodge += item.GetComponent<Armor>().dodge;
                }
                else if(item.GetComponent<Item>() is Weapon)
                {
                    totalAtk += item.GetComponent<Weapon>().damage;
                }
            }
        }
        builder.Append("\n");
        builder.Append("Total Defense: " + totalDef + "\n");
        builder.Append("Total Dodge: " + totalDodge + "\n");
        builder.Append("Total Attack: " + totalAtk + "\n");
        invText.text = builder.ToString();
    }
}

namespace UnityEngine.EventSystems
{
    public interface IHasChanged : IEventSystemHandler
    {
        void HasChanged();
    }
}