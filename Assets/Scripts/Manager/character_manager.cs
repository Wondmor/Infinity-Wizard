using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_manager : MonoBehaviour
{

    public GameObject character1;

    public GameObject character2;
    void Start()
    {
        string characterName = PlayerPrefs.GetString("CharacterName");
        if(characterName=="1")
        {


            character1.gameObject.SetActive(true);
            character2.gameObject.SetActive(false);
        }
        else
        {


            character2.gameObject.SetActive(true);
            character1.gameObject.SetActive(false);
        }
    }

}
