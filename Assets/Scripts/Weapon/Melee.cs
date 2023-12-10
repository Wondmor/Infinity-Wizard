using System;
using System.Collections;
using System.Collections.Generic;
using ClearSky;
using UnityEngine;

public class Melee : MonoBehaviour
{
    public GameObject owner;

    private void OnEnable()
    {
        Transform parentTransform = transform.parent;
        owner = parentTransform.gameObject;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {   
            other.GetComponent<Health>().TakeDamage(owner.GetComponent<Enemy>().attack);
            //ObjectPool.Instance.PushObject(gameObject);
        }
        
        
    }
}
