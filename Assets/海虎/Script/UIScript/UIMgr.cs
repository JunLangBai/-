using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMgr : MonoBehaviour
{
    public static UIMgr Instance; //单例
    
    void Awake()
    {
        if (Instance == null)
            Instance = this;
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
