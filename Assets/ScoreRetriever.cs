using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreRetriever : MonoBehaviour {

    public GameObject gameManager;

	// Update is called once per frame
	void Update () {
        GetComponent<Text>().text = gameManager.GetComponent<GameManagerScript>().score.ToString();
	}
}
