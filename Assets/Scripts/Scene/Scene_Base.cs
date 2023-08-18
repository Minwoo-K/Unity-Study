using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Scene_Base : MonoBehaviour
{
    protected Define.Scenes currentScene = Define.Scenes.None;

    private void Awake()
    {
        Init();
    }

    public virtual void Init()
    {
        if ( GameObject.Find("#GameManager") == null )
        {
            GameObject gm = new GameObject() { name = "#GameManager" };
            gm.AddComponent<GameManager>();
        }

        if (GameObject.FindObjectOfType<EventSystem>() == null)
        {
            GameObject evtsys = GameManager.Resource.Instantiate("UI/EventSystem");
            evtsys.name = "#EventSystem";
            DontDestroyOnLoad(evtsys);
        }
    }

    public string GetCurrentSceneName()
    {
        return System.Enum.GetName(typeof(Define.Scenes), currentScene);
    }

}
