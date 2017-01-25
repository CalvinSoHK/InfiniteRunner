using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {

    public bool homing = false;
    DetectFurthest detectScript;

    public float powerupDuration = 5f;
    private float powerupTimer = 0f;

    public GameObject gameManager;

    private float oldSpeed = 0f;
    private bool oldSpeedRetrieved = false;

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
                GetComponent<Rigidbody>().AddForce(targetVector * 20);
                GetComponent<ParticleSystem>().startSpeed = 20;
                GetComponent<ParticleSystem>().startSize = 2f;
                if (!oldSpeedRetrieved)
                {
                    oldSpeed = gameManager.GetComponent<GameManagerScript>().speed;
                    oldSpeedRetrieved = true;
                }
                
                gameManager.GetComponent<GameManagerScript>().speed = gameManager.GetComponent<GameManagerScript>().maxSpeed;
            }
           
        }
        else
        {
            GetComponent<ParticleSystem>().startSpeed = 10f;
            GetComponent<ParticleSystem>().startSize = 1f;
           
        }

        if(powerupTimer < powerupDuration && homing)
        {
            powerupTimer += Time.deltaTime;
        }
        else if(powerupTimer >= powerupDuration && homing)
        {
            homing = false;
            powerupTimer = 0f;
            gameManager.GetComponent<GameManagerScript>().speed = oldSpeed;
            oldSpeedRetrieved = false;
        }
       
		
	}
}
