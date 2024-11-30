using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void Restart()
    {
        // 获取当前场景的名字
        string currentSceneName = SceneManager.GetActiveScene().name;
        
        Time.timeScale = 1f;
        
        // 重新加载当前场景
        SceneManager.LoadScene(currentSceneName);
        
    }

    public void Quit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartScenes");
    }
}
