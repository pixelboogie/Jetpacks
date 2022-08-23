using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject SpawnPrefab; // which prefab we will be spawning
    public Transform SpawnLocation; // the location we will spawn the SpawnedPrefab
    public float spawnDelay = 1.0f; // time to remain before spawning next
    public float spawnInterval = 30.0f; // time interval for spawning each 


    void Update()
    {
        spawnDelay -= Time.deltaTime;
        if (spawnDelay < 0)
        {
            var SpawnedPrefab = Instantiate(SpawnPrefab, SpawnLocation.position, SpawnLocation.transform.rotation);
            spawnDelay = spawnInterval;
        }
    }
}
