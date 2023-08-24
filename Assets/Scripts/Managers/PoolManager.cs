using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager
{
    #region Pool
    private class Pool
    {
        private Transform Root;                                     // The Root object of this Pool
        private GameObject Original;                                // The original object of the Pool
        private Stack<Poolable> thePool = new Stack<Poolable>();    // The Pool

        private int size;                                           // Size of the Pool
        public bool resizeable = true;                              // Whether the given pool is resizeable or not
        
        public void Init(GameObject original, int size, bool resizeable = true)
        {
            if (Root == null)
            {
                GameObject go = GameObject.Find($"#Pool: {Original.name}");
                if (go == null)
                {
                    go = new GameObject() { name = $"#Pool: {Original.name}" };
                    Root = go.transform;
                }

                Root.parent = GameManager.Pool.Root;

                this.Original = original;
                this.size = size;
                this.resizeable = resizeable;

                for (int i = 0; i < size; i++)
                {
                    thePool.Push(LoadCopy());
                }
            }
        }

        public GameObject GetOriginal()
        {
            return Original;
        }

        private Poolable LoadCopy()
        {
            GameObject clone = Object.Instantiate<GameObject>(Original);
            clone.name = Original.name;
            clone.SetActive(false);
            Poolable poolable = clone.AddOrGetComponent<Poolable>();
            poolable.transform.parent = Root;
            poolable.inUse = false;

            return poolable;
        }

        public Poolable Pop(Transform parent = null)
        {
            Poolable poolable = null;

            if ( thePool.Count == 0 )
            {
                if ( resizeable )
                {
                    poolable = LoadCopy();
                    Push(poolable);
                    size++;
                }
                else
                {
                    Debug.Log($"The Pool has reached its limit of use: {Original.name}");
                    return null;
                }
            }
            else
            {
                poolable = thePool.Pop();
            }

            poolable.inUse = true;
            poolable.gameObject.SetActive(true);
            if ( parent != null )
                poolable.transform.parent = parent;

            return poolable;
        }

        public void Push(Poolable poolable)
        {
            if ( poolable == null )
                return;

            poolable.inUse = false;
            poolable.gameObject.SetActive(false);
            poolable.transform.parent = Root;
            thePool.Push(poolable);
        }

        public void Clear()
        {
            while ( thePool.Count != 0)
            {
                Poolable poolable = thePool.Pop();
                Object.Destroy(poolable);
                poolable = null;
            }

            thePool.Clear();
            Root = null;
            Original = null;
        }
    }
    #endregion

    public Transform Root;

    private Dictionary<string, Pool> Pools = new Dictionary<string, Pool>();

    public void Init()
    {
        if (Root == null)
        {
            GameObject go = GameObject.Find("#PoolManager");
            if (go == null)
            {
                go = new GameObject() { name = "#PoolManager" };
                Root = go.transform;
            }
        }

    }

    public void CreatePool(GameObject original, int size, bool resizeable = true)
    {
        Pool pool = new Pool();
        pool.Init(original, size, resizeable);
        Pools.Add(original.name, pool);
    }

    public GameObject Pop(GameObject original, Transform parent = null)
    {
        Pool pool = null;
        Poolable poolable = null;

        if ( Pools.TryGetValue(original.name, out pool) )
        {
            poolable = pool.Pop(parent);
        }
        else
        {
            if (original.GetComponent<Poolable>() != null)
            {
                CreatePool(original, 5);
                pool = Pools[original.name];
                poolable = pool.Pop(parent);
            }
        }

        if ( poolable == null )
        {
            Debug.Log($"Failed to pop from the Pool: {original.name}");
            return null;
        }
        
        return poolable.gameObject;
    }

    public void Push(Poolable poolable)
    {
        if (Pools.ContainsKey(poolable.name))
        {
            Pools[poolable.name].Push(poolable);
            Debug.Log("Successfully pooled back");
        }
    }

    public void Clear()
    {
        foreach (Transform transform in Root)
        {
            Object.Destroy(transform);
            Pools.Clear();
        }
    }
}
