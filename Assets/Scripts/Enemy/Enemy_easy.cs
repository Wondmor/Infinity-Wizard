using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_easy : MonoBehaviour
{
    public int health;
    public int damage;
    public float flashTime;


    private SpriteRenderer sr; 
    private Color originalColor;

    

    // Start is called before the first frame update
    public void Start()
    {
       
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
    }

    // Update is called once per frame
    public void Update()
    {
        if (health <= 0)
        {

            Destroy(gameObject);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            TakeDamage(1);
        }
    }

    public void TakeDamage(int damage)
    {


        health -= damage;
        FlashColor(flashTime);


    }

    void FlashColor(float time)
    {
        sr.color = Color.red;
        Invoke("ResetColor", time);
    }

    void ResetColor()
    {
        sr.color = originalColor;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {

        }
    }
}