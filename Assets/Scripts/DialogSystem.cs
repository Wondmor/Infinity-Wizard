using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    public TextMeshProUGUI textLabel;
    public Image faceImage;

    public TextAsset textFile;
    public int index;

    List<string> textlist = new List<string>();

    void Awake()
    {
        GetTextformFile(textFile);
        index=0;
    }

    private void OnEnable()
    {
        textLabel.text=textlist[index];
        index++;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            textLabel.text = textlist[index];
            index++;
        }
        if(Input.GetKeyDown(KeyCode.R) && index==textlist.Count)
        {
            gameObject.SetActive(false);
            index=0;
            return;
        }
    }

    void GetTextformFile(TextAsset file)
    {
        textlist.Clear();
        index=0;
        var lineData = file.text.Split('\n');

        foreach(var line in lineData)
        {
            textlist.Add(line);
        }
    }
}
