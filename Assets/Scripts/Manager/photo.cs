using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class photo : MonoBehaviour
{

    public GameObject player1;

    public GameObject player2;
    // Start is called before the first frame update
    void Start()
    {
        string characterName = PlayerPrefs.GetString("CharacterName");
        if (characterName == "1")
        {
            player1.SetActive(true);
        }
        else if (characterName == "2")
        {
            player2.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Character Name not recognized. Using default playerPrefab1.");
            player1.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
