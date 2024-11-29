using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartScene_Controller : MonoBehaviour
{

    public bool isThanks = false;
    public bool isHelps = false;
    
    public GameObject ThanksPic;
    public GameObject HelpPic;
    
    
    
    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Thanks()
    {
        if (isThanks)
        {
            UIMgr.Instance.CloseUI(ThanksPic);
            isThanks = false;
        }
        else
        {
            UIMgr.Instance.OpenUI(ThanksPic);
            isThanks = true;
            
        }
    }

    public void Help()
    {
        if (isHelps)
        {
            UIMgr.Instance.CloseUI(HelpPic);
            isHelps = false;
        }
        else
        {
            UIMgr.Instance.OpenUI(HelpPic);
            isHelps = true;
            
        }
    }

    public void ExitGame()
    {
        // 如果是在编辑器中运行，使用 UnityEditor 的功能退出播放模式
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            // 在发布的应用中，退出游戏
            Application.Quit();
#endif
    }
}
