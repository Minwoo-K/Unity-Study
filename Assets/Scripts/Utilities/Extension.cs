using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public static class Extension
{
    public static UI_EventHandler AddEventHandler(this GameObject go, Action<PointerEventData> action, Define.EventType evtType = Define.EventType.Click)
    {
        return Utils.AddEventHandler(go, action, evtType);
    }

    public static T AddOrGetComponent<T>(this GameObject go) where T: Component
    {
        return Utils.AddOrGetComponent<T>(go);
    }
}
