using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler{

    //GUIElement guiIcon;


    Vector3 startPos;
    public static GameObject grabbedObject;
    Transform startParent;


	// Use this for initialization
	void Start () {
	
	}

    void Awake()
    {
        //guiIcon = GetComponent<GUIElement>();
    }
	
	// Update is called once per frame
	void Update () {
	    
	}
    /*
    void OnMouseDown()
    {
        dragging = true;
        grabbedObject = gameObject;
        Debug.Log("MouseDown");
        dragCopy = Instantiate(gameObject);
        //dragCopy.renderer.material.color = Color.blue;
        prevMousePos = Input.mousePosition;
        prevMousePos = Camera.main.ScreenToWorldPoint(prevMousePos);
    }

    void OnMouseDrag()
    {
        Vector3 newMousePos = Input.mousePosition;
        newMousePos = Camera.main.ScreenToWorldPoint(newMousePos);

        dragCopy.transform.Translate(newMousePos - prevMousePos);



        prevMousePos = newMousePos;
    }

    void OnMouseUp()
    {
        if(dragging)
        {
            
        }
        dragging = false;


    }
    */
    public void OnBeginDrag(PointerEventData eventData)
    {
        startPos = transform.position;
        grabbedObject = gameObject;
        startParent = transform.parent;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        grabbedObject = null;
        if (transform.parent == startParent)
        {
            transform.position = startPos;
        }
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
