using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{

    [SerializeField]
    private List<PoolableMono> _poolingList;

    private void Awake()
    {
        PoolManager.Instance = new PoolManager(transform); // ���ӸŴ����� Ǯ�� �θ�� �ؼ� Ǯ�Ŵ����̱��� ����
        foreach (PoolableMono p in _poolingList)
        {
            PoolManager.Instance.CreatePool(p, 20);
        }
    }
}