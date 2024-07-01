using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PoolingData
{

    public PoolableMono PoolObject;
    public int Count;

}


[CreateAssetMenu(fileName = "PoolingListSO", menuName = "SO/Pool/PoolingList")]
public class PoolingListSO : ScriptableObject
{

    public List<PoolingData> PoolingList;

}
