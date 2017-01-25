using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {

    public bool homing = false;
    DetectFurthest detectScript;

    public float powerupDuration = 5f;
    private float powerupTimer = 0f;


	// Use this for initialization
	void Start () {
        detectScript = transform.GetChild(0).GetComponent<DetectFurthest>();
	}
	
	// Update is called once per frame
	void Update () {

        if (homing && detectScript.nextNode != null)
        {
            if(transform.position.x < 3f)
            {
                Transform targetTransform = detectScript.nextNode.transform;

                Vector3 targetVector = targetTransform.position - transform.position;
                GetComponent<Rigidbody>().AddForce(targetVector * 10);
            }
           
        }

        if(powerupTimer < powerupDuration && homing)
        {
            powerupTimer += Time.deltaTime;
        }
        else if(powerupTimer >= powerupDuration && homing)
        {
            homing = false;
            powerupTimer = 0f;
        }
       
		
	}
}
