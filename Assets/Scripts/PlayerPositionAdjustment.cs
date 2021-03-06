﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionAdjustment : MonoBehaviour {

    public float catchupSpeed = 2f;


    public float bounceSpeed = 0.1f;

    public bool lerping = false;

    public Vector3 originalPosition;
    private float bounceTimer = 0f;

    private GameObject indicator;
    public bool gravityNormal = true;

    void Start()
    {
        catchupSpeed = GameObject.Find("GameManager").GetComponent<GameManagerScript>().catchupSpeed;
        indicator = GameObject.Find("Indicator");
    }

	// Update is called once per frame
	void Update () {
		if(transform.position.x < 0)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.right * 10 * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Physics.gravity = -Physics.gravity;
            gravityNormal = !gravityNormal;
            indicator.transform.eulerAngles += new Vector3(0, 0, 180);
        }



        /*
        if(targetCursor != null)
        {
            Vector3 movementVector = targetCursor.transform.position - transform.position;
            GetComponent<Rigidbody>().AddForce(movementVector * 10f);
        }
        
        if(GetComponent<Rigidbody>().velocity.magnitude < 1f)
        {
            ManualNextTargetCursor();
        }*/
	}

    /*
    void ManualNextTargetCursor()
    {   
        Destroy(targetCursor);
    }

    public void NextTargetCursor()
    {
        targetCursors.Remove(targetCursor);
        if(targetCursors.Count > 0)
        {
            targetCursor = targetCursors[0];
        }
        else
        {
            targetCursor = null;
            StartCoroutine(SearchNextCursor());
        }
       
    }

    public void AddTargetCursor(GameObject cursor)
    {
        targetCursors.Add(cursor);
    }

    IEnumerator SearchNextCursor()
    {
        while(targetCursor == null)
        {
            if(targetCursors.Count > 0)
            {
                targetCursor = targetCursors[0];
            }
            yield return new WaitForSeconds(0.2f);
        }
    }*/

}
