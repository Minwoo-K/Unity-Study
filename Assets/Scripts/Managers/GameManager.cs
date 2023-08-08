using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    private ResourceManager _resource = new ResourceManager();

    public static GameManager Instance { get { Init(); return _instance; } }
    public static ResourceManager Resource { get { return Instance._resource; } }

    void Start()
    {
        Init();

        Resource.Instantiate("Box");
    }

    void Update()
    {
        
    }

    public static void Init()
    {
        if (_instance == null)
        {
            GameObject go = GameObject.Find("#GameManager");
            if (go == null)
            {
                go = new GameObject() { name = "#GameManager" };
                go.AddComponent<GameManager>();
            }

            _instance = go.GetComponent<GameManager>();
            DontDestroyOnLoad(go);
        }
    }
}
