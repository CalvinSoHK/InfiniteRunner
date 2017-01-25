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



    public Vector3 gravity = new Vector3(0, -9.8f, 0);

    public Color collectibleColor, blockColor;
    public Material collectibleAsset, blockAsset;

    public float colorDuration, colorChangeTime, colorTimer = 0f;
    private bool colorChange = false;
    private Color oldCollectibleColor, oldBlockColor;
    private float colorStepTime = 0f;

    void Start()
    {
        StartCoroutine(IncreaseSpeed());
        Physics.gravity = gravity;
        collectibleColor = collectibleAsset.color;
        blockColor = blockAsset.color;

        Physics.IgnoreLayerCollision(0, 8, true);
    }

	// Update is called once per frame
	void Update () {
        
        if(colorTimer < colorDuration)
        {
            colorTimer += Time.deltaTime;
        }
        else if(!colorChange)
        {
            colorChange = true;
            oldBlockColor = blockColor;
            oldCollectibleColor = collectibleColor;
            blockColor = Random.ColorHSV();
            collectibleColor = Random.ColorHSV();
        }

        if (colorChange)
        {
            colorStepTime += (1.0f / colorChangeTime) * Time.deltaTime;
            blockAsset.color = Color.Lerp(oldBlockColor, blockColor, colorStepTime);
            collectibleAsset.color = Color.Lerp(oldCollectibleColor, collectibleColor, colorStepTime);
            if(colorStepTime >= 1.0f)
            {
                colorChange = false;
                colorStepTime = 0f;
                colorTimer = 0f;
                
            }
        }
       
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
