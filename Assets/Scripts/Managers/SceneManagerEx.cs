using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SceneManagerEx
{
    public Scene_Base currentScene { get { return Object.FindObjectOfType<Scene_Base>(); } }

    public void LoadScene(Define.SceneType SceneType)
    {
        string sceneName = GetSceneName(SceneType);
        currentScene.Clear();
        SceneManager.LoadScene(sceneName);
        GameManager.Init();
    }

    private string GetSceneName(Define.SceneType SceneType)
    {
        return System.Enum.GetName(typeof(Define.SceneType), SceneType);
    }
}
