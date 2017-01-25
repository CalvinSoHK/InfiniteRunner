using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillAllScript : MonoBehaviour {

    public GameObject DrawBox, GameOverText;

    void OnTriggerEnter(Collider col)
    {
        //Debug.Log(col.name);
        if(col.gameObject.name == "Player")
        {
            GameOverText.SetActive(true);
            Destroy(col.gameObject);
        }
        else if (col.gameObject.name.Contains("FloorTile"))
        {
            DrawBox.GetComponent<DrawBoxes>().SpawnFloor(col.gameObject);
        }
        else if (col.gameObject.name.Contains("Collectible"))
        {
            Destroy(col.gameObject);
        }
       
    }
}
