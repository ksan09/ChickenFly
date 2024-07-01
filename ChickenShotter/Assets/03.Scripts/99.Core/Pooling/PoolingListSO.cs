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

    [Header("Pooling Object")]
    public List<PoolingData> PoolingList;

    [Header("Pooling Sound")]
    public List<PoolingData> PoolingSoundList;

    [Header("Pooling Effect")]
    public List<PoolingData> PoolingEffectList;

}
