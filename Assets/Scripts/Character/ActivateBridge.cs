using UnityEngine;
using System.Collections;

public class ActivateBridge : MonoBehaviour {
    public GameObject[] bridgePieces;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "SkillTrainer" && FindCraftsman.CraftsmanFound)
        {
            for (int i = 0; i < bridgePieces.Length; ++i)
            {
                bridgePieces[i].SetActive(false);
            }
        }
    }
}
