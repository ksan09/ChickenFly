using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoSingleton<PoolManager>
{

    private Dictionary<string, PoolableMono<PoolableMono>> _pools = new Dictionary<string, PoolableMono<PoolableMono>>();

    [Header("Info")]
    [SerializeField]
    private Transform _trmParent;
    [SerializeField]
    private PoolingListSO _poolingList;

    public override void Init()
    {

        if(_trmParent == null)
            _trmParent = transform;

        foreach(var pool in _poolingList.PoolingList)
        {

            CreatePool(pool.PoolObject, pool.Count);

        }

        foreach (var pool in _poolingList.PoolingEffectList)
        {

            CreatePool(pool.PoolObject, pool.Count);

        }

        foreach (var pool in _poolingList.PoolingSoundList)
        {

            CreatePool(pool.PoolObject, pool.Count);

        }

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
        item.transform.SetParent(null);
        item.Reset();
        return item;
    }
    public PoolableMono Pop(string prefabName, Transform parentTrm)
    {
        if (_pools.ContainsKey(prefabName) == false)
        {
            Debug.LogError("Prefab doesnt exist on poolList");
            return null;
        }

        PoolableMono item = _pools[prefabName].Pop();
        item.transform.SetParent(parentTrm);
        item.Reset();
        return item;
    }
    public PoolableMono Pop(string prefabName, Vector3 position, Quaternion rotation)
    {
        if (_pools.ContainsKey(prefabName) == false)
        {
            Debug.LogError("Prefab doesnt exist on poolList");
            return null;
        }

        PoolableMono item = _pools[prefabName].Pop();
        item.transform.SetParent(null);
        item.transform.position = position;
        item.transform.rotation = rotation;

        item.Reset();
        return item;
    }
    public PoolableMono Pop(string prefabName, Vector3 position, Vector3 eulerAngles)
    {
        if (_pools.ContainsKey(prefabName) == false)
        {
            Debug.LogError("Prefab doesnt exist on poolList");
            return null;
        }

        PoolableMono item = _pools[prefabName].Pop();
        item.transform.SetParent(null);
        item.transform.position = position;
        item.transform.eulerAngles = eulerAngles;

        item.Reset();
        return item;
    }

    public void Push(PoolableMono obj)
    {

        obj.transform.SetParent(_trmParent);
        _pools[obj.name].Push(obj);

    }
}
