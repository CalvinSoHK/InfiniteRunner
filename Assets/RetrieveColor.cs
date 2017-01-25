using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetrieveColor : MonoBehaviour {

    public GameObject gameManager;
	
	// Update is called once per frame
	void Update () {
        GetComponent<Material>().color = gameManager.GetComponent<GameManagerScript>().blockColor;
	}
}
