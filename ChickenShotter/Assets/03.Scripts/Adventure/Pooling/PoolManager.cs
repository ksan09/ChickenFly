using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager
{
    public static PoolManager Instance;

    private Dictionary<string, PoolableMono<PoolableMono>> _pools = new Dictionary<string, PoolableMono<PoolableMono>>();


    private Transform _trmParent;

    public PoolManager(Transform trmParent)
    {
        _trmParent = trmParent;
    }

    public void CreatePool(PoolableMono prefab, int cnt = 10)
    {
        PoolableMono<PoolableMono> pool = new PoolableMono<PoolableMono>(prefab, _trmParent, cnt);
        _pools.Add(prefab.gameObject.name, pool);
    }

    public PoolableMono Pop(string prefabName)
    {
        if (_pools.ContainsKey(prefabName) == false)
        {
            Debug.LogError("Prefab doesnt exist on poolList");
            return null;
        }

        PoolableMono item = _pools[prefabName].Pop();
        item.Reset();
        return item;
    }

    public void Push(PoolableMono obj)
    {
        _pools[obj.name].Push(obj);
    }
}
