using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public static GameControl Instance; //单例

    public int moveBoxID = 1;
    
    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void ChangeMoveBoxID()
    {
        moveBoxID++;
    }
}
