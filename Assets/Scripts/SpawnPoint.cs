using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public float spawnTime;
    public int spawnNumber;
    public float spawnRange;


    private float _lastSpawnTime;

    void Update()
    {
        if (Time.time - _lastSpawnTime >= spawnTime && spawnNumber > 0)
        {
            Vector3 randSpawnPosition = new Vector3(Random.Range(-spawnRange, spawnRange), Random.Range(-spawnRange, spawnRange), 0f);
            randSpawnPosition += gameObject.transform.position;
            Spawn(prefabToSpawn, randSpawnPosition);
        }
    }

    void Spawn(GameObject spawnPrefab, Vector3 spawnPosition)
    {
        GameObject newGameObject = ObjectPool.Instance.GetObject(spawnPrefab);
        newGameObject.transform.position = spawnPosition;

        _lastSpawnTime = Time.time;
        spawnNumber--;
    }
    
    

}