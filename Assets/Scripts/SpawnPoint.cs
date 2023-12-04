using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public float spawnTime;
    public int spawnNumber;

    private float _lastSpawnTime;

    void Update()
    {
        if (Time.time - _lastSpawnTime >= spawnTime && spawnNumber > 0)
        {
            Vector3 randSpawnPosition = new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), 0f);
            randSpawnPosition += gameObject.transform.position;
            Spawn(prefabToSpawn, randSpawnPosition);
        }
    }

    void Spawn(GameObject spawnPrefab, Vector3 spawnPosition)
    {
        GameObject newGameObject = ObjectPool.Instance.GetObject(spawnPrefab);
        newGameObject.transform.position = spawnPosition;

        var behaviorTree = newGameObject.GetComponent<BehaviorTree>();
        behaviorTree.SetVariableValue("Self", newGameObject);
        behaviorTree.SetVariableValue("Home", gameObject);

        _lastSpawnTime = Time.time;
        spawnNumber--;
    }
}