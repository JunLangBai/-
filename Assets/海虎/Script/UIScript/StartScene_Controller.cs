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
        // 直接调用过渡场景切换
        TransitionToScene("Level1");
    }

    public void TransitionToScene(string targetSceneName)
    {
        // 1. 加载过渡场景
        StartCoroutine(LoadSceneWithTransition(targetSceneName));
    }

    private IEnumerator LoadSceneWithTransition(string targetSceneName)
    {
        // 2. 记录当前场景，以便稍后卸载
        string currentSceneName = SceneManager.GetActiveScene().name;

        // 3. 加载过渡场景
        yield return SceneManager.LoadSceneAsync("TransitionScene", LoadSceneMode.Additive);
        
        // 4. 异步加载目标场景
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(targetSceneName, LoadSceneMode.Additive);
        
        // 等待目标场景加载完成
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // 5. 显示过渡场景一秒钟
        yield return new WaitForSeconds(1f);

        // 6. 卸载过渡场景
        SceneManager.UnloadSceneAsync("TransitionScene");

        // 7. 卸载之前的场景
        if (currentSceneName != targetSceneName)
        {
            SceneManager.UnloadSceneAsync(currentSceneName);
        }
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
