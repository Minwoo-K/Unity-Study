using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    private ResourceManager _resource = new ResourceManager();
    private InputManager _input = new InputManager();
    private UIManager _ui = new UIManager();
    private SceneManagerEx _scene = new SceneManagerEx();
    private SoundManager _sound = new SoundManager();
    private PoolManager _pool = new PoolManager();

    public static GameManager Instance { get { Init(); return _instance; } }
    public static ResourceManager Resource { get { return Instance._resource; } }
    public static InputManager Input { get { return Instance._input; } }
    public static UIManager UI { get { return Instance._ui; } }
    public static SceneManagerEx Scene { get { return Instance._scene; } }
    public static SoundManager Sound { get { return Instance._sound; } }
    public static PoolManager Pool { get { return Instance._pool; } }

    void Start()
    {
        Init();
    }

    void Update()
    {
        Input.UpdateInput();
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
            //DontDestroyOnLoad(go);

            _instance._ui.Init();
            _instance._sound.Init();
            _instance._pool.Init();
        }
    }

    public static void Clear()
    {
        _instance._sound.Clear();
        _instance._ui.Clear();
        _instance._pool.Clear();
    }
}
