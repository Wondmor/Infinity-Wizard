using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levelchange : MonoBehaviour
{
    public GameObject Button;

    public GameObject player;

    public Transform teleportPosition;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Button.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Button.SetActive(false);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Button.activeSelf && Input.GetKeyDown(KeyCode.R))
        {
            if (teleportPosition != null && player != null)
            {
                player.transform.position = teleportPosition.position;
            }
        }
    }
}
