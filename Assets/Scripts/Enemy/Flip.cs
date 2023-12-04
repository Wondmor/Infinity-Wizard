using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks.Unity.UnityGameObject;
using UnityEngine;

public class Flip : MonoBehaviour
{


    void OnEnable()
    {
        StartCoroutine(FlipCharacter());
    }


    
    IEnumerator FlipCharacter()
    {
        while (true)
        {
            Vector3 previousPosition = transform.position;
            yield return new WaitForSeconds(0.1f);
            Vector3 currentPosition = transform.position;
            float xVelocity = currentPosition.x - previousPosition.x;
            if (xVelocity > -0.2f && xVelocity < 0.2f)
            {
                GameObject player = GameObject.FindWithTag("Player");
                if (currentPosition.x > player.transform.position.x)
                {
                    FlipSprite(2);
                }
                else
                {
                    FlipSprite(-2);
                }
            }
            else
            {
                if (currentPosition.x >= previousPosition.x)
                {
                    FlipSprite(-2);
                }
                else
                {
                    FlipSprite(2);
                }
            }
            
        }
        yield return null;
    }

    void FlipSprite(float i)
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x = i;
        gameObject.transform.localScale = currentScale;
    }
}
