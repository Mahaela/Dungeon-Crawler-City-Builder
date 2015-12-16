using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class Slot : MonoBehaviour, IDropHandler {

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
            if (slotType == 0 || slotType == Drag.grabbedObject.GetComponent<Item>().type)
            {
                transform.GetChild(0).gameObject.transform.SetParent(Drag.startParent);
                Drag.grabbedObject.transform.SetParent(transform);
                ExecuteEvents.ExecuteHierarchy<IHasChanged>(gameObject, null, (x, y) => x.HasChanged());
            }
        }
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
