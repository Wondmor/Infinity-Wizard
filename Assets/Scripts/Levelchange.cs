using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levelchange : MonoBehaviour
{
    public GameObject Button;
    private GameObject objectToTeleport; // Store reference to the object that triggered the collider

    public Transform teleportPosition;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Button.SetActive(true);
        objectToTeleport = other.gameObject; // Store the reference to the object that triggered the collider
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Button.SetActive(false);
        objectToTeleport = null; // Reset the reference when the object exits the collider
    }

    void Update()
    {
        if (Button.activeSelf && Input.GetKeyDown(KeyCode.R))
        {
            if (teleportPosition != null && objectToTeleport != null)
            {
                objectToTeleport.transform.position = teleportPosition.position;
            }
        }
    }
}