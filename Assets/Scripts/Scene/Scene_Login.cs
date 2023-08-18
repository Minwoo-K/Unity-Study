using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_Login : Scene_Base
{
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            GameManager.Scene.LoadScene(Define.Scenes.Game);
        }    
    }

    public override void Init()
    {
        base.Init();

        currentScene = Define.Scenes.Login;

        Debug.Log(GameManager.Scene.currentScene);
        Debug.Log($"Current Scene: {System.Enum.GetName(typeof(Define.Scenes), currentScene)}");
    }
}
