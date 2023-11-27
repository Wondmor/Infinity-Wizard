using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrop : MonoBehaviour
{
    public GameObject drop;
    private void OnDisable()
    {
        GameObject newObject = Instantiate(drop, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
