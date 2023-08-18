using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SceneManagerEx
{
    public Scene_Base currentScene { get; private set; }

    public void Init()
    {
        
    }

    public void LoadScene<T>(string name) where T: Scene_Base
    {
        

    }
}
