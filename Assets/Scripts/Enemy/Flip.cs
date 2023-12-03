using System.Collections;
using System.Collections.Generic;
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
            if (currentPosition.x >= previousPosition.x)
            {
                Vector3 currentScale = gameObject.transform.localScale;
                currentScale.x = -2;
                gameObject.transform.localScale = currentScale;
            }
            else
            {
                Vector3 currentScale = gameObject.transform.localScale;
                currentScale.x = 2;
                gameObject.transform.localScale = currentScale;
            }
        }
        
        yield return null;
    }
}
