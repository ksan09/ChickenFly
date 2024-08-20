using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StageMonsterListSO", menuName = "SO/Map/StageMonsterListSO")]
public class StageMonsterListSO : ScriptableObject
{

    [Header("해당 스테이지에서 나올 몬스터 리스트")]
    public List<PoolableMono> StageMonsterList;

    [Header("해당 스테이지에서 나올 방해 오브젝트 리스트")]
    public List<PoolableMono> StageDangerObjectList;

    [Header("최소 스폰 몬스터 수 ~ 최대 스폰 몬스터 수")]
    public int MinSpawnCount;
    public int MaxSpawnCount;

}
