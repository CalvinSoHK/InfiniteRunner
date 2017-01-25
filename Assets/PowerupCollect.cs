using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupCollect : MonoBehaviour {

	void OnTriggerEnter(Collider col)
    {
        if(col.name == "Player")
        {
            col.GetComponent<Powerup>().homing = true;
            Destroy(gameObject);
        }
    }
}
