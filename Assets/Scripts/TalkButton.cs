using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TalkButton : MonoBehaviour
{
    public GameObject Button;
    public GameObject talkUI;

    protected GameObject player;
    public bool heal=false;

    private bool he=false;


    private void OnTriggerEnter2D(Collider2D other)
    {
        Button.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Button.SetActive(false);
        talkUI.SetActive(false);
    }

    private void Update()
    {
        player = GameObject.FindWithTag("Player");
        if (Button.activeSelf && Input.GetKeyDown(KeyCode.R))
        {
            talkUI.SetActive(true);
            if(heal==true && he==false)
            {
                player.GetComponent<Health>().Heal();
                he=true;
            }
        }
    }

}
