using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_manager : MonoBehaviour
{
    public Camera mainCamera1;
    public Camera mainCamera2;

    public GameObject character1;

    public GameObject character2;
    void Start()
    {
        string characterName = PlayerPrefs.GetString("CharacterName");
        if(characterName=="1")
        {
            mainCamera1.gameObject.SetActive(true);
            mainCamera2.gameObject.SetActive(false);

            character1.gameObject.SetActive(true);
            character2.gameObject.SetActive(false);
        }
        else
        {
            mainCamera2.gameObject.SetActive(true);
            mainCamera1.gameObject.SetActive(false);

            character2.gameObject.SetActive(true);
            character1.gameObject.SetActive(false);
        }
    }

}
