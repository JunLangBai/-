using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMgr : MonoBehaviour
{
    public static UIMgr Instance { get; private set; }
    
    public AudioClip soundClip;      // 音效文件

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // 保持对象在场景切换时不被销毁
        }
        else
        {
            Destroy(gameObject);  // 销毁重复的实例
        }
    }

    public void PlaySound(AudioSource audioSource)
    {
        // 播放音效
        audioSource.clip = soundClip;
        audioSource.Play();
    }

    public void OpenUI(GameObject UI)
    {
        UI.SetActive(true);
    }

    public void CloseUI(GameObject UI)
    {
        UI.SetActive(false);
    }
}
