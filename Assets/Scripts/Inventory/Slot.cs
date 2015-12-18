using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class Slot : MonoBehaviour, IDropHandler, IPointerClickHandler
{
    public static GameObject currentModItem;
    enum types {non, head, body, hand, foot, weapon};

    public int slotType;

    public GameObject item
    {
        get
        {
            if(transform.childCount > 0)
            {
                return transform.GetChild(0).gameObject;
            }
            return null;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        //place in empty
        if(!item)
        {
            if(slotType == 0 || slotType == Drag.grabbedObject.GetComponent<Item>().type)
            {
                Drag.grabbedObject.transform.SetParent(transform);
                ExecuteEvents.ExecuteHierarchy<IHasChanged>(gameObject, null, (x, y) => x.HasChanged());
            }
            
        }
        else
        {
            //swap
            if (slotType == 0 || slotType == Drag.grabbedObject.GetComponent<Item>().type)
            {
                transform.GetChild(0).gameObject.transform.SetParent(Drag.startParent);
                Drag.grabbedObject.transform.SetParent(transform);
                ExecuteEvents.ExecuteHierarchy<IHasChanged>(gameObject, null, (x, y) => x.HasChanged());
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {

        Debug.Log("click");
        //cleanup old mod item
        if (currentModItem)
        {
            foreach (GameObject mod in currentModItem.GetComponent<Equips>().mods)
            {
                Debug.Log("restructuring");

                if (mod)
                {
                    //return to parent
                    mod.GetComponent<CanvasGroup>().alpha = 0;
                    mod.GetComponent<CanvasGroup>().blocksRaycasts = false;
                    mod.SetParent(currentModItem);
                }
            }
        }
        GameObject modPanel = GameObject.Find("ModPanel");
        foreach (Transform child in modPanel.transform)
        {
            child.gameObject.SetActive(false);//instead of destroying
            currentModItem = null;
        }
        //GameObject item = gameObject.GetComponent<Item>().gameObject;
        if (item && item.GetComponent<Equips>() != null)
        {
            
            Debug.Log("has item");
 
            Debug.Log("is moddable");
            currentModItem = item;
            int i = 0;
            
            foreach (GameObject mod in item.GetComponent<Equips>().mods)
            {
                //Load current mods
                Debug.Log("In Slots: "+mod);

                //Display all mods in current item
                /*
                GameObject tempslot = (GameObject)Instantiate(Resources.Load("ModSlot"));
                tempslot.SetParent(modPanel);
                */
                GameObject tempslot = modPanel.transform.GetChild(i).gameObject;
                tempslot.SetActive(true);

                if (mod)
                {

                    //GameObject tempmod = Instantiate(mod);
                    //tempmod.GetComponent<CanvasGroup>().alpha = 1;
                    //tempmod.GetComponent<StoreInformation>().enabled = false;
                    //tempmod.SetActive(true);
                    //tempmod.SetParent(tempslot);
                    mod.GetComponent<CanvasGroup>().alpha = 1;
                    mod.GetComponent<CanvasGroup>().blocksRaycasts = true;
                    mod.SetParent(tempslot);
                }
                i++;
            }

        }
        /*
        else
        {
            //disable mod portion
            foreach (GameObject mod in item.GetComponent<Equips>().mods)
            {
                Debug.Log("restructuring");

                if (mod)
                {

                    mod.GetComponent<CanvasGroup>().alpha = 0;
                    mod.SetParent(currentModItem);
                }
            }

            foreach (Transform child in modPanel.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            currentModItem = null;
        }*/
        
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
