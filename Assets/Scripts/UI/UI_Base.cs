using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class UI_Base : MonoBehaviour
{
    protected Dictionary<Type, UnityEngine.Object[]> UI_Storage = new Dictionary<Type, UnityEngine.Object[]>();

    private void Awake()
    {
        Init();
    }

    public abstract void Init();

    public void Bind<T>(Type type) where T : UnityEngine.Object
    {
        string[] names = Enum.GetNames(type);
        UnityEngine.Object[] objects = new UnityEngine.Object[names.Length];
        UI_Storage.Add(typeof(T), objects);

        for (int i = 0; i < names.Length; i++)
        {
            if (typeof(T) == typeof(GameObject))
            {
                objects[i] = Utils.FindChild(gameObject, names[i], true);
            }
            else
            {
                objects[i] = Utils.FindChild<T>(gameObject, names[i], true);
            }
        }
    }

    public T Get<T>(int index) where T : UnityEngine.Object
    {
        UnityEngine.Object[] objects = null;
        if (UI_Storage.TryGetValue(typeof(T), out objects))
        {
            return objects[index] as T;
        }

        Debug.Log($"Couldn't find the {index}th object in {typeof(T)}");
        return null;
    }
    public Image GetImage(int index) { return Get<Image>(index); }
    public Button GetButton(int index) { return Get<Button>(index); }
    public TextMeshProUGUI GetText(int index) { return Get<TextMeshProUGUI>(index); }

    public static UI_EventHandler AddUIEvent(GameObject go, Action<PointerEventData> action, Define.EventType evtType = Define.EventType.Click)
    {
        UI_EventHandler eventHandler = go.AddOrGetComponent<UI_EventHandler>();

        switch (evtType)
        {
            case Define.EventType.Click:
                eventHandler.ClickHandler -= action;
                eventHandler.ClickHandler += action;
                break;
            case Define.EventType.Drag:
                eventHandler.DragHandler -= action;
                eventHandler.DragHandler += action;
                break;
        }

        return eventHandler;
    }
}
