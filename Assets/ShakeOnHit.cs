using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeOnHit : MonoBehaviour
{

    public GameObject mainCamera;
    private bool shaken = false;

    void OnCollisionEnter(Collision col)
    {
        if(col.collider.transform.root.name == "FloorTiles" && !shaken)
        {
            mainCamera.GetComponent<CameraShake>().Shake(0.2f, 0.2f);
            shaken = true;
        }
    }

    void OnCollisionExit(Collision col)
    {
        
        if (col.collider.transform.root.name == "FloorTiles")
        {
            shaken = false;
        }
    }

}
