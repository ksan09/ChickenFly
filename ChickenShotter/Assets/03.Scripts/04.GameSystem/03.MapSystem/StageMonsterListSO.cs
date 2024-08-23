using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StageMonsterListSO", menuName = "SO/Map/StageMonsterListSO")]
public class StageMonsterListSO : ScriptableObject
{

    [Header("해당 스테이지에서 나올 몬스터 리스트")]
    public List<SpawnMonsterDataList> StageMonsterList;

    [Header("해당 스테이지에서 나올 방해 오브젝트 리스트")]
    public List<PoolableMono> StageDangerObjectList;

}
