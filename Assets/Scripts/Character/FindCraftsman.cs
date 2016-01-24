using UnityEngine;
using System.Collections;

public class FindCraftsman : MonoBehaviour {
    static bool isCraftsmanFound;
    public GameObject craftsman;

    // Use this for initialization
    void Start() {
        isCraftsmanFound = false;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject == craftsman)
        {
            isCraftsmanFound = true;
        }
    }

    public static bool CraftsmanFound {
        get {
            return isCraftsmanFound;
        }
    }
}
