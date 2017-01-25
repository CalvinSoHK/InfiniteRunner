using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCursorTrigger : MonoBehaviour {

	void OnTriggerEnter(Collider col)
    {
        Debug.Log("collision");
        if(col.name == "Player")
        {
            col.GetComponent<PlayerPositionAdjustment>().NextTargetCursor();
            Destroy(gameObject);
        }
    }
}
