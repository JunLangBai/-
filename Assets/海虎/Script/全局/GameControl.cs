using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public static GameControl Instance; //单例

    public int moveBoxID = 1;
    public int GoToLevelCount;
    
    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void ChangeMoveBoxID()
    {
        moveBoxID++;
    }

    public void GoToNextlevel(GameObject player)
    {
        if (GoToLevelCount < 2)
        {
            Vector2 dir = new Vector2(player.transform.position.x, player.transform.position.y + 100);
            player.transform.Translate(dir);
            GoToLevelCount++;
            ChangeMoveBoxID();
        }
        else
        {
            CantGoNextLevel();
        }
    }

    public void CantGoNextLevel()
    {
        Debug.Log("CantGoNextLevel");
    }
}
