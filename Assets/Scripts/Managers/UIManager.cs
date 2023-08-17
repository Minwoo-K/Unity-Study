using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager
{
    protected Stack<UI_Popup> PopupUI_Storage = new Stack<UI_Popup>();  // Where to save all of Pop-up UIs
    protected UI_Scene SceneUI = null;                                  // Where to save ONE scene UI
    public int SortingOrder { get; set; }                            // To track order of Pop-up UIs
    public Transform UI_Root { get; private set; } = null;

    public void Init()
    {
        GameObject go = GameObject.Find("#UI");
        if (go == null)
        {
            go = new GameObject() { name = "#UI" };
            UI_Root = go.transform;
        }

        SortingOrder = 10;

        if ( GameObject.FindObjectOfType<EventSystem>() == null )
        {
            GameObject evtsys = GameManager.Resource.Instantiate("UI/EventSystem");
            evtsys.name = "#EventSystem";
            Object.DontDestroyOnLoad(evtsys);
        }

        ShowSceneUI<UI_Interface>();
    }

    public T ShowPopupUI<T>(string path = null) where T: UI_Popup
    {
        if ( path == null )
            path = typeof(T).Name;

        GameObject clone = GameManager.Resource.Instantiate($"UI/UI_Popup/{path}");
        if ( clone == null )
        {
            Debug.LogError($"Couldn't find the Popup-UI: {path} in the Resources folder");
            return null;
        }

        T popup = clone.AddOrGetComponent<T>();
        popup.name = path;
        popup.transform.SetParent(UI_Popup.PopupUI_Root);

        PopupUI_Storage.Push(popup);

        return popup;
    }

    public T ShowSceneUI<T>(string path = null) where T: UI_Scene
    {
        if (path == null)
            path = typeof(T).Name;

        GameObject clone = GameManager.Resource.Instantiate($"UI/UI_Scene/{path}");
        if (clone == null)
        {
            Debug.LogError($"Couldn't find the Scene-UI: {path} in the Resources folder");
            return null;
        }

        T scene = clone.AddOrGetComponent<T>();
        SceneUI = scene;
        scene.name = path;
        scene.transform.SetParent(UI_Root);

        return scene;
    }
}
