using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SceneManagerEx
{
    public Scene_Base currentScene { get { return Object.FindObjectOfType<Scene_Base>(); } }

    public void LoadScene(Define.Scenes SceneType)
    {
        string sceneName = GetSceneName(SceneType);
        SceneManager.LoadScene(sceneName);
    }

    private string GetSceneName(Define.Scenes SceneType)
    {
        return System.Enum.GetName(typeof(Define.Scenes), SceneType);
    }
}
