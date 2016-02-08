using UnityEngine;

public class Level7Switch : MonoBehaviour {
    public bool top;
    public Material activeMat;

    private Transform river;
    private bool activated = false;

    void Start()
    {
        if (top)
            river = transform.parent.parent.parent.Find("Crossing").Find("Acheron").Find("RiverCenterTop");
        else
            river = transform.parent.parent.parent.Find("Crossing").Find("Acheron").Find("RiverCenterBottom");
    }

    public void run()
    {
        if (!activated)
        {
            river.gameObject.SetActive(false);
            activated = true;
            gameObject.GetComponent<Renderer>().material = activeMat;
        }
    }
}
