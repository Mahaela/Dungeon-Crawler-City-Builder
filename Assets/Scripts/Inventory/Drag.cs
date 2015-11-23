using UnityEngine;
using System.Collections;

public class Drag : MonoBehaviour {

    GUIElement guiIcon;

	// Use this for initialization
	void Start () {
	
	}

    void Awake()
    {
        guiIcon = GetComponent<GUIElement>();
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnMouseDown()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
    }
}
