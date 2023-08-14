using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
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
}
