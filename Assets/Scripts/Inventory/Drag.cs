using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler{

    //GUIElement guiIcon;

    


    Vector3 startPos;
    public static GameObject grabbedObject;
    public static Transform startParent;
    Transform canvas;

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

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

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
