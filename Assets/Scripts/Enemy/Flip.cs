using System.Collections;
using UnityEngine;

public class Flip : MonoBehaviour
{

    public float scale;
    
    void OnEnable()
    {
        StartCoroutine(FlipCharacter());
        scale = gameObject.transform.localScale.x;
        if (scale < 0) scale = -scale;
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
                    FlipSprite(scale);
                }
                else
                {
                    FlipSprite(-scale);
                }
            }
            else
            {
                if (currentPosition.x >= previousPosition.x)
                {
                    FlipSprite(-scale);
                }
                else
                {
                    FlipSprite(scale);
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
