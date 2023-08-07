using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance { get { Init(); return instance; } }

    void Start()
    {
        Init();
    }

    void Update()
    {
        
    }

    public static void Init()
    {
        if (instance == null)
        {
            GameObject go = GameObject.Find("#GameManager");
            if (go == null)
            {
                go = new GameObject() { name = "#GameManager" };
                go.AddComponent<GameManager>();
            }

            instance = go.GetComponent<GameManager>();
            DontDestroyOnLoad(go);
        }
    }
}
