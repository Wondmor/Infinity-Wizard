using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    public TextMeshProUGUI textLabel;
    public GameObject player1;

    public GameObject player2;

    private GameObject playerImage;
    public GameObject npcImage;

    public TextAsset textFile;
    private int index;


    List<string> textlist = new List<string>();


    void Awake()
    {

        string characterName = PlayerPrefs.GetString("CharacterName");
        if (characterName == "1")
        {
            playerImage = player1;
        }
        else if (characterName == "2")
        {
            playerImage = player2;
        }
        else
        {
            Debug.LogWarning("Character Name not recognized. Using default playerPrefab1.");
            playerImage = player1;
        }
        
        GetTextformFile(textFile);
        index = 0;
        ToggleFaceImages(false); // Initially, hide both face images
    }

    private void OnEnable()
    {
        ShowNextText();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (index < textlist.Count)
            {
                ShowNextText();
            }
            else
            {
                gameObject.SetActive(false);
                index = 0;
            }
        }
    }

    void ShowNextText()
    {
        textLabel.text = textlist[index];

        // Toggle between face images when showing text
        ToggleFaceImages(index % 2 == 0);

        index++;
    }

    void ToggleFaceImages(bool showImage2)
    {
        playerImage.SetActive(!showImage2);
        npcImage.SetActive(showImage2);
    }

    void GetTextformFile(TextAsset file)
    {
        textlist.Clear();
        index = 0;
        var lineData = file.text.Split('\n');

        foreach (var line in lineData)
        {
            textlist.Add(line);
        }
    }
}
