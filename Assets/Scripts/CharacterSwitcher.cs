using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CharacterSwitcher : MonoBehaviour
{
   public Transform playerPrefab1; // 第一个角色的预制件
    public Transform playerPrefab2; // 第二个角色的预制件

    public CinemachineVirtualCamera virtualcamera;
    void Start()
    {
        // 检索参数
        string characterName = PlayerPrefs.GetString("CharacterName");



        if (characterName == "1")
        {
            virtualcamera.Follow=playerPrefab1;
        }
        else if (characterName == "2")
        {
            virtualcamera.Follow=playerPrefab2;
        }
        else
        {
            Debug.LogWarning("Character Name not recognized. Using default playerPrefab1.");
            virtualcamera.Follow=playerPrefab1;
        }

    }
}
