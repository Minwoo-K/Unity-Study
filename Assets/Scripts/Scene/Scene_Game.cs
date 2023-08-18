using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_Game : Scene_Base
{
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            GameManager.Scene.LoadScene(Define.SceneType.Login);
        }
    }

    public override void Init()
    {
        base.Init();

        currentScene = Define.SceneType.Game;

        Debug.Log(GameManager.Scene.currentScene);
        Debug.Log($"Current Scene: {System.Enum.GetName(typeof(Define.SceneType), currentScene)}");
    }
}
