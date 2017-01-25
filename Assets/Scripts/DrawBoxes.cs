using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawBoxes : MonoBehaviour {

    public GameObject floorTile, collectible, powerup;
    public float spawnTime = 0.2f, yMin = -10f, yMax = -3f, yMinGlobal, yMaxGlobal;

    //private bool powerupSpawned = false;

    private Vector3 lastRandomPosition = new Vector3(10, -8, 0);

    void Start()
    {
        StartCoroutine(SpawnCollectibleCoroutine());
        StartCoroutine(SpawnPowerupCoroutine());
    }

    public void SpawnFloor(GameObject floorTile)
    {
        Vector3 spawnPosition = lastRandomPosition;
        spawnPosition.y = Mathf.Clamp(spawnPosition.y + Random.Range(-1f, 1f), yMin, yMax);
        
        lastRandomPosition = spawnPosition;
        floorTile.transform.localPosition = spawnPosition;
    }

    public void SpawnCollectible()
    {
        Vector3 spawnPosition = lastRandomPosition;
        spawnPosition.y = Mathf.Clamp(spawnPosition.y + Random.Range(1f, 3f) + 10f, yMinGlobal, yMaxGlobal);

        GameObject temp = Instantiate(collectible, spawnPosition, Quaternion.identity);
        temp.transform.parent = GameObject.Find("Collectible").transform;
    }

    public void SpawnPowerup()
    {
        Vector3 spawnPosition = lastRandomPosition;
        //powerupSpawned = true;
        spawnPosition.y = Mathf.Clamp(spawnPosition.y + Random.Range(1f, 3f) + 10f, yMinGlobal, yMaxGlobal);

        GameObject temp = Instantiate(collectible, spawnPosition, Quaternion.identity);
        
    }

    IEnumerator SpawnPowerupCoroutine()
    {
        while (true)
        {
            SpawnPowerup();
            yield return new WaitForSeconds(Random.Range(5f, 10f));
        }
    }

    IEnumerator SpawnCollectibleCoroutine()
    {
        while (true)
        {
            SpawnCollectible();
            yield return new WaitForSeconds(Random.Range(0.2f, 5f));
        }
    }

    /*
    IEnumerator SpawnFloorCoroutine()
    {
        while (true)
        {
            SpawnFloor();
        } 
    }*/
}
