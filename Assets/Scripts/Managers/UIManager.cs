using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager
{
    protected Stack<UI_Popup> PopupUI_Storage = new Stack<UI_Popup>();  // Where to save all of Pop-up UIs
    protected UI_Scene SceneUI = null;                                  // Where to save ONE scene UI
    public int SortingOrder { get; set; }                            // To track order of Pop-up UIs
    public Transform UI_Root { get; private set; }
    public Transform PopupUI_Root { get; private set; }

    public void Init()
    {
        GameObject go = GameObject.Find("#UI");
        if (go == null)
        {
            go = new GameObject() { name = "#UI" };
            UI_Root = go.transform;

            GameObject go2 = new GameObject() { name = "#Popup UI" };
            PopupUI_Root = go2.transform;
            PopupUI_Root.SetParent(UI_Root);
        }

        SortingOrder = 10;

        // Testing
        ShowSceneUI<UI_Interface>();
        ShowPopupUI<UI_Inventory>();
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
        //popup.transform.SetParent(UI_Popup.PopupUI_Root);
        SortingOrder++;

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

    public void ClosePopupUI()
    {
        if (PopupUI_Storage.Count == 0)
            return;

        GameManager.Resource.Destroy(PopupUI_Storage.Pop().gameObject);
        SortingOrder--;
    }

    public void ClosePopupUI(UI_Popup popup)
    {
        if (PopupUI_Storage.Peek() != popup)
        {
            Debug.LogError("Closing a non-latest PopupUI is not allowed.");
            return;
        }

        ClosePopupUI();
    }

    public void CloseAllPopupUI()
    {
        while (PopupUI_Storage.Count != 0)
            ClosePopupUI();
    }

    public void Clear()
    {
        PopupUI_Storage.Clear();
        SceneUI = null;
        UI_Root = null;
        PopupUI_Root = null;
    }
}
