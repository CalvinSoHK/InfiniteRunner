using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {

    public float speed = 2f;
    public float catchupSpeed = 5f;
    public float acceleration = 0.5f;
    public float accelerationRate = 1f;
    public float maxSpeed = 10f;

    public float score = 0f;
	
    void Start()
    {
        StartCoroutine(IncreaseSpeed());
    }

	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator IncreaseSpeed()
    {
        while (true)
        {
            if(speed < maxSpeed)
            {
                speed += acceleration;
            }
            else
            {
                speed = maxSpeed;
            }
            
            yield return new WaitForSeconds(accelerationRate);
        }
    }
}
