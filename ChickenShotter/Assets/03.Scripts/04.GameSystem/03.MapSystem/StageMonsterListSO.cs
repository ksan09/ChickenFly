using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StageMonsterListSO", menuName = "SO/Map/StageMonsterListSO")]
public class StageMonsterListSO : ScriptableObject
{

    [Header("�ش� ������������ ���� ���� ����Ʈ")]
    public List<PoolableMono> StageMonsterList;

    [Header("�ش� ������������ ���� ���� ������Ʈ ����Ʈ")]
    public List<PoolableMono> StageDangerObjectList;

    [Header("�ּ� ���� ���� �� ~ �ִ� ���� ���� ��")]
    public int MinSpawnCount;
    public int MaxSpawnCount;

}
