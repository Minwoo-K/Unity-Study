using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
    public T Load<T>(string path) where T: UnityEngine.Object
    {
        return Resources.Load<T>(path);
    }

    public GameObject Instantiate(string path, Transform parent = null)
    {
        GameObject clone = Load<GameObject>($"Prefabs/{path}");
        if (clone == null)
        {
            Debug.Log($"[ResourceManager>Instantiate]: Couldn't find the object on [Prefabs/{path}]");
            return null;
        }

        GameObject go = Object.Instantiate(clone);
        go.name = path;
        
        if (parent != null) go.transform.parent = parent;

        return go;
    }

    public void Destroy(GameObject go, float inTime = 0)
    {
        if (go == null)
        {
            Debug.Log($"[ResourceManager>Destroy]: the object {go.name} doesn't exist!");
            return;
        }

        Object.Destroy(go, inTime);
    }
}
