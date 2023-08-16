using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public static class Extension
{
    public static UI_EventHandler AddUIEvent(this GameObject go, Action<PointerEventData> action, Define.EventType evtType = Define.EventType.Click)
    {
        return UI_Base.AddUIEvent(go, action, evtType);
    }

    public static T AddOrGetComponent<T>(this GameObject go) where T: Component
    {
        return Utils.AddOrGetComponent<T>(go);
    }
}
