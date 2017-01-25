using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCode : MonoBehaviour {

    private float speed = 0.5f;


    void Start()
    {
       
    }

    void Update()
    {
        speed = GameObject.Find("GameManager").GetComponent<GameManagerScript>().speed;
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
