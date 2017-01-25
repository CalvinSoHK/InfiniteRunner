using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectFurthest : MonoBehaviour {

    public GameObject nextNode;

    void OnTriggerEnter(Collider col)
    {
        if(col.name == "MiddleIndicator")
        {
            if(nextNode == null)
            {
                nextNode = col.gameObject;
            }
            else if(col.transform.position.x > nextNode.transform.position.x)
            {
                nextNode = col.gameObject;
            }
        }
    }
}
