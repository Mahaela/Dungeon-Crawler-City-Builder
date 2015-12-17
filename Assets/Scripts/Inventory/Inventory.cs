using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class Inventory : MonoBehaviour, IHasChanged {
    [SerializeField] Transform slots; 
    [SerializeField] Text invText;
    [SerializeField] Transform modSlots;
    

	// Use this for initialization
	void Start () {
        HasChanged();
        /*
        SaveLoad.Instance.GetInvArray();
        Debug.Log("Generating Inventory");

        int count = 0;
        foreach (int i in SaveLoad.Instance.inventoryList)
        {
            GameObject temp = Instantiate(ItemTable.Instance.getItemAtIndex(i));
            Transform slot = transform.GetChild(0).transform.GetChild(count);
            temp.transform.SetParent(slot);
            Debug.Log(temp.name);
            count++;
        }
        */
    }

    void Awake()
    {
        
    }
	
	// Update is called once per frame
	void Update () {

        
	}

    public void HasChanged()
    {
        //adjust weapon mods
        
        int i = 0;
        if (Slot.currentModItem)
        {
            foreach (Transform slotTransform in modSlots)
            {
                if(slotTransform.gameObject.activeSelf == true)
                {
                    Slot.currentModItem.GetComponent<Equips>().mods[i] = slotTransform.GetComponent<Slot>().item;
                }
                


                i++;
                Debug.Log(slotTransform.GetComponent<Slot>().item);
            }
        }




        //calculate total bonuses
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
                builder.Append(item.name);

                if(item.GetComponent<Item>() is Equips)
                {
                    builder.Append(" ( ");
                    foreach (GameObject mod in item.GetComponent<Equips>().mods)
                    {
                        if(mod)
                        {
                            builder.Append(mod.name + " ");
                            totalDef += mod.GetComponent<ItemMods>().defBoost;
                            totalDodge += mod.GetComponent<ItemMods>().dodgeBoost;
                            totalAtk += mod.GetComponent<ItemMods>().atkBoost;
                        }
                        else
                        {
                            builder.Append(" Empty Slot ");
                        }
                    }
                    builder.Append(") ");

                }

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