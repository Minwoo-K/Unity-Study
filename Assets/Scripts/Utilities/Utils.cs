using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public static class Utils
{
    public static T AddOrGetComponent<T>(GameObject go) where T: Component
    {
        T component = go.GetComponent<T>();
        if ( component == null )
        {
            component = go.AddComponent<T>();
        }

        return component;
    }

    public static T FindChild<T>(GameObject TopParent, string name = null, bool recursive = false) where T : UnityEngine.Object
    {
        if (recursive)
        {
            foreach (T component in TopParent.GetComponentsInChildren<T>())
            {
                if (string.IsNullOrEmpty(name) || component.name == name)
                    return component;
            }
        }
        else
        {
            for (int i = 0; i < TopParent.transform.childCount; i++)
            {
                Transform transform = TopParent.transform.GetChild(i);
                T component = transform.GetComponent<T>();
                if (string.IsNullOrEmpty(name) || component.name == name)
                    return component;
            }
        }

        Debug.Log($"Couldn't find the \"{typeof(T).Name}\" component or \"{name}\" in {TopParent.name} object");
        return null;
    }

    public static GameObject FindChild(GameObject TopParent, string name = null, bool recursive = false)
    {
        Transform child = FindChild<Transform>(TopParent, name, recursive);
        return child.gameObject;
    }

    public static UI_EventHandler AddEventHandler(GameObject go, Action<PointerEventData> action, Define.EventType evtType = Define.EventType.Click)
    {
        UI_EventHandler eventHandler = AddOrGetComponent<UI_EventHandler>(go);

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
