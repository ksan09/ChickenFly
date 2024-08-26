using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StageMonsterListSO", menuName = "SO/Map/StageMonsterListSO")]
public class StageMonsterDataSO : ScriptableObject
{

    [Header("점수마다 스폰되는 몬스터 수 [ Min, Max ]")]
    public List<MinMaxData<int>> StageSpawnCountData = new List<MinMaxData<int>>(10);

    [Header("[ 몬스터, 소환 시작 스테이지, 소환 끝 스테이지, 가중치 ]")]
    public List<SpawnMonsterData> StageMonsterList;

    [Header("[ 방해물, 소환 시작 스테이지, 소환 끝 스테이지, 가중치 ]")]
    public List<SpawnMonsterData> StageDangerList;

}
