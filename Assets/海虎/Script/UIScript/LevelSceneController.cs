using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSceneController : MonoBehaviour
{
    public GameObject stopBg;
    private bool isPaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        if (isPaused)
        {
            UIMgr.Instance.CloseUI(stopBg);
            Time.timeScale = 1f;
            isPaused = false;
        }
        else
        {
            UIMgr.Instance.OpenUI(stopBg);
            Time.timeScale = 0f;
            isPaused = true;
            
        }
    }
}
