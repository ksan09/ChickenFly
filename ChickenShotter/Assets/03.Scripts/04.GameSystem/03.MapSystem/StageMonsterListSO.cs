using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StageMonsterListSO", menuName = "SO/Map/StageMonsterListSO")]
public class StageMonsterListSO : ScriptableObject
{

    [Header("�ش� ������������ ���� ���� ����Ʈ")]
    public List<SpawnMonsterDataList> StageMonsterList;

    [Header("�ش� ������������ ���� ���� ������Ʈ ����Ʈ")]
    public List<PoolableMono> StageDangerObjectList;

}
