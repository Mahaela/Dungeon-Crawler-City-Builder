using UnityEngine;
using System.Collections;

public class ActivateBridge : MonoBehaviour {
    public GameObject skillTrainer;
    public GameObject[] bridgePieces;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject == skillTrainer && FindCraftsman.CraftsmanFound)
        {
            for (int i = 0; i < bridgePieces.Length; ++i)
            {
                bridgePieces[i].SetActive(false);
            }
        }
    }
}
