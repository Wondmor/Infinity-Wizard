using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public float spawnTime;
    public int spawnNumber;
    void Start()
    {
        
    }

    private float _lastSpawnTime;
    void Update()
    {
        if (Time.time - _lastSpawnTime >= spawnTime && spawnNumber > 0)
        {
            GameObject newGameObject = ObjectPool.Instance.GetObject(prefabToSpawn);
            newGameObject.transform.position = gameObject.transform.position;
            var behaviorTree = newGameObject.GetComponent<BehaviorTree>();
            behaviorTree.SetVariableValue("Self", newGameObject);
            behaviorTree.SetVariableValue("Home", gameObject);
            _lastSpawnTime = Time.time;
            spawnNumber--;
        }
        
    }
}
