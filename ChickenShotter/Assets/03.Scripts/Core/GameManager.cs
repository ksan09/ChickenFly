using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{

    [SerializeField]
    private List<PoolableMono> _poolingList;

    private void Awake()
    {
        PoolManager.Instance = new PoolManager(transform); // 게임매니저를 풀링 부모로 해서 풀매니저싱글톤 생성
        foreach (PoolableMono p in _poolingList)
        {
            PoolManager.Instance.CreatePool(p, 20);
        }
    }
}