using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public static GameControl Instance{ get; private set; }//单例
    

    public int moveBoxID = 1;
    public int moveBoxID2 = 0;
    public int GoToLevelCount;
    public int CoinCount = 0;
    
    public CanvasGroup cantGoGroup;
    public float waitTime;
    
    void Awake()
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

    private void Start()
    {
        ResetAll();
    }

    public void ChangeMoveBoxID()
    {
        moveBoxID++;
    }

    public void GoToNextlevel(GameObject player)
    {
        if (GoToLevelCount < 2)
        {
            Vector2 dir = new Vector2(0f,100f);
            player.transform.Translate(dir);
            GoToLevelCount++;
            ChangeMoveBoxID();
        }
        else
        {
            cantGoGroup.alpha = 1;
            CantGoNextLevel();
        }
    }

    public void CantGoNextLevel()
    {
        StartCoroutine(dontgo(cantGoGroup,waitTime));
    }

    private IEnumerator dontgo(CanvasGroup cv,float delay)
    {
        yield return new WaitForSeconds(delay);  // 等待指定的时间
        cv.alpha = 0;  // 隐藏文字
    }

    public void ResetAll()
    {
        moveBoxID = 1;
        CoinCount = 0;
        GoToLevelCount = 0;
        moveBoxID2 = 0; 
    }
}
