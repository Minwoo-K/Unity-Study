using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_Game : Scene_Base
{
    void Start()
    {
        GameManager.Sound.Play("UnityChan/univ1335", Define.AudioSourceType.Background);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            GameManager.Scene.LoadScene(Define.SceneType.Login);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            GameManager.Sound.Play("UnityChan/univ1278");
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
