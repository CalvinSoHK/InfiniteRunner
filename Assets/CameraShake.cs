using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

    private Vector3 originalPosition;
    private bool shake = false;
    private float intensity = 1f, duration = 1f;
    private float timer = 0f;

    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        if (shake)
        {
            if(timer <= duration)
            {
                transform.position = originalPosition + Random.insideUnitSphere * intensity;
                timer += Time.deltaTime;
            }
            else
            {
                timer = 0f;
                transform.position = originalPosition;
                shake = false;
            }
        }
    }

	public void Shake(float newIntensity, float newDuration)
    {
        intensity = newIntensity;
        duration = newDuration;
        shake = true;
    }
}
