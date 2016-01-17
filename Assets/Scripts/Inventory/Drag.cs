using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

/*
 * Name: Drag
 * Desc: Script for dragging items in inventory.
 */
public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler{

    //GUIElement guiIcon;

    Vector3 startPos; //initial position of icon before drag
    public static GameObject grabbedObject; //holds the item being dragged to be accessed from other scripts.
    public static Transform startParent; //the initial slot dragged from
    Transform canvas;

    /*
     * Name: OnBeginDrag
     * Desc: Save the initial position, the object grabbed, and the initial slot.
     */
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("start drag");
        startPos = transform.position;
        grabbedObject = gameObject;
        startParent = transform.parent;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        canvas = GameObject.FindGameObjectWithTag("UI Canvas").transform;
        transform.SetParent(canvas);
    }

    /*
     * Name: OnDrag
     * Desc: move the icon with the mouse when dragging
     */
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    /*
     * Name: OnEndDrag
     * Desc: reset the position if was unable to be put in another slot
     */
    public void OnEndDrag(PointerEventData eventData)
    {
        grabbedObject = null;
        if (transform.parent == canvas)
        {
            transform.position = startPos;
            transform.SetParent(startParent);
        }
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    
}
