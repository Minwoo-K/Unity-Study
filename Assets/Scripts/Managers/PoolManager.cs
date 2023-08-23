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

        public Poolable Pop(Transform parent)
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
                    return null;
                }
            }
            else
            {
                poolable = thePool.Pop();
            }

            poolable.inUse = true;
            poolable.gameObject.SetActive(true);
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

    }

    public Poolable Pop()
    {
        return null;
    }

    public void Push(Poolable poolable)
    {

    }

    public void Clear()
    {

    }
}
