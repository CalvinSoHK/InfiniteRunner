using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCode : MonoBehaviour {

    public float value = 0f;

	void OnTriggerEnter(Collider col)
    {
        if(col.name == "Player")
        {
            GameObject.Find("GameManager").GetComponent<GameManagerScript>().score += value;
            GameObject.Find("Main Camera").GetComponent<CameraShake>().Shake(0.2f, 0.2f);
            Destroy(gameObject);
        }
    }
}
