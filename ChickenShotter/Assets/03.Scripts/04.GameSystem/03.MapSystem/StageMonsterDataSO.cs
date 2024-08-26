using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StageMonsterListSO", menuName = "SO/Map/StageMonsterListSO")]
public class StageMonsterDataSO : ScriptableObject
{

    [Header("�������� �����Ǵ� ���� �� [ Min, Max ]")]
    public List<MinMaxData<int>> StageSpawnCountData = new List<MinMaxData<int>>(10);

    [Header("[ ����, ��ȯ ���� ��������, ��ȯ �� ��������, ����ġ ]")]
    public List<SpawnMonsterData> StageMonsterList;

    [Header("[ ���ع�, ��ȯ ���� ��������, ��ȯ �� ��������, ����ġ ]")]
    public List<SpawnMonsterData> StageDangerList;

}
