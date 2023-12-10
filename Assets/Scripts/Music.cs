using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
// 在 Inspector 视图中指定背景音乐的 AudioClip
    public AudioClip backgroundMusicClip;

// AudioSource 组件用于播放音频
    private AudioSource audioSource;

    void Start()
    {
        // 获取或添加 AudioSource 组件
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // 指定要播放的音频剪辑
        audioSource.clip = backgroundMusicClip;

        // 设置 AudioSource 循环播放
        audioSource.loop = true;

        // 开始播放背景音乐
        audioSource.Play();
    }
}