using UnityEngine;
using System.Collections;

public class FindCraftsman : MonoBehaviour {
    static bool isCraftsmanFound;

    // Use this for initialization
    void Start() {
        isCraftsmanFound = false;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Craftsman")
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
