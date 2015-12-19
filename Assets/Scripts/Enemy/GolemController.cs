using UnityEngine;
using System.Collections;

public class GolemController : MonoBehaviour {

	public GameObject[] golems;
	int index;
	// Use this for initialization
	void Start () {
		for (int i = 0; i < golems.Length; i++) {
			golems[i].GetComponent<GolemHealth>().controller = this;
			golems[i].GetComponent<GolemHealth>().index = i;
		}
		index = 0;
		Activate (index);
	}

	void Activate (int i)
	{
		golems [i].GetComponentInChildren<GolemAttack>().enabled = true;
		golems [i].GetComponent<GolemHealth>().enabled = true;
		golems [i].GetComponent<EnemyMovement>().enabled = true;
		golems [i].GetComponent<Rigidbody2D>().isKinematic = false;
		
	}
	// Update is called once per frame
	public void dead(int i)
	{
		if (i == index) {
			index++;
			if(index < golems.Length)
			{
				Activate (index);
			}
		}
	}
}
