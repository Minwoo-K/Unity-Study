using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_Game : Scene_Base
{
    private Stack<Poolable> pooledObjects = new Stack<Poolable>();
    void Start()
    {
        GameManager.Sound.Play("UnityChan/univ1335", Define.AudioSourceType.Background);
        Poolable go = GameManager.Resource.Instantiate("Box").GetComponent<Poolable>();
        pooledObjects.Push(go);
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

        if (Input.GetKeyDown(KeyCode.S))
        {
            Poolable go = GameManager.Resource.Instantiate("Box").GetComponent<Poolable>();
            pooledObjects.Push(go);
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            Poolable go = pooledObjects.Pop();
            GameManager.Resource.Destroy(go.gameObject);
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
