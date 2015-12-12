using UnityEngine;
using System.Collections;

public class Drag : MonoBehaviour {

    //GUIElement guiIcon;

    GameObject dragCopy;
    Vector3 prevMousePos;
    private static bool dragging = false;
    private static GameObject grabbedObject;


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
            if()
        }
        dragging = false;


    }

}
