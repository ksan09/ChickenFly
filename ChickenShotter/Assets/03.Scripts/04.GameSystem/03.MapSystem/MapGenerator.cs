using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class MapGenerator : MonoBehaviour
{

    [SerializeField]
    private List<StageMonsterDataSO> _spawnMobList;

    // 100������ ������ ����
    StageMonsterDataSO _spawnStageMonsterData;

    // ����ġ�� ���� ������ �ֱ�
    List<string> _stageDangerObjectWeightData;
    List<string> _stageMonsterWeightData;

    public void Generate(int score)
    {

        int stage = (score % 100) / 10;

        if (score % 100 == 1)
            _spawnStageMonsterData = Instantiate(_spawnMobList[score / 100]);
        if (score % 10 == 1)
            SetDataSetting(stage);

        EnemyGenerate(stage);
        DisturbanceGenerate();

    }

    private void SetDataSetting(int stage)
    {
        
        // �⺻���� ������
        List<SpawnMonsterData> stageDangerObjectData  = _spawnStageMonsterData.StageDangerList.ToList<SpawnMonsterData>();
        List<SpawnMonsterData> stageMonsterData       = _spawnStageMonsterData.StageMonsterList.ToList<SpawnMonsterData>();

        _stageDangerObjectWeightData    = new List<string>();
        _stageMonsterWeightData         = new List<string>();

        // 
        for(int i = 0; i < stageDangerObjectData.Count; i++)
        {

            SpawnMonsterData data = stageDangerObjectData[i];

            if (stage > data.SpawnEnd || stage < data.SpawnStart)
                continue;

            for(int j = 0; j < data.Weight; ++j)
            {

                _stageDangerObjectWeightData.Add(data.Monster.name);

            }

        }

        for (int i = 0; i < stageMonsterData.Count; i++)
        {

            SpawnMonsterData data = stageMonsterData[i];

            if (stage > data.SpawnEnd || stage < data.SpawnStart)
                continue;

            for (int j = 0; j < data.Weight; ++j)
            {

                _stageMonsterWeightData.Add(data.Monster.name);

            }

        }


    }

    // 3���� 1 Ȯ���� ���ع� ����
    private void DisturbanceGenerate()
    {

        List<string> spawnDangerWeightList = _stageDangerObjectWeightData.ToList<string>();
        
        if (spawnDangerWeightList.Count <= 0)   // ��ȯ�� ���� ������Ʈ�� ���� �����̸� X
            return;
        
        float per = Random.Range(0f, 1f);
        if(per <= 0.33f)
        {
        
            // Create
            List<float> spawnPosYList = new List<float>() { -5.75f, -4.25f, -2.75f, -1.25f, -0.75f, 1.25f, 2.75f, 4.25f };
        
            int randomSpawnYIndex = Random.Range(0, spawnPosYList.Count);
            float spawnPosY = spawnPosYList[randomSpawnYIndex];
        
            string spawnDangerObjectName = spawnDangerWeightList[Random.Range(0, spawnDangerWeightList.Count)];
            DangerObject dangerObject = 
                PoolManager.Instance.Pop("Danger", new Vector3(16.5f, spawnPosY),Quaternion.identity) as DangerObject;
        
            if (dangerObject != null)
            {
        
                dangerObject.Init(spawnDangerObjectName);
        
            }
        
        }



    }

    // �� ���� ���� �� �ϳ��� ����
    private void EnemyGenerate(int stage)
    {

        int spawnCount = Random.Range(_spawnStageMonsterData.StageSpawnCountData[stage].Min, _spawnStageMonsterData.StageSpawnCountData[stage].Max + 1);
        List<string> stageMonsterList = _stageMonsterWeightData.ToList<string>();
        List<float> spawnPosYList = new List<float>() { -5.75f, -4.25f, -2.75f, -1.25f, -0.75f, 1.25f, 2.75f, 4.25f };
       

        for (int i = 0; i < spawnCount; i++)
        {

            int randomSpawnMonsterIndex = Random.Range(i, stageMonsterList.Count);
            int randomSpawnYIndex = Random.Range(i, spawnPosYList.Count);

            float spawnPosX = Random.Range(19.5f, 20.5f);
            float spawnPosY = spawnPosYList[randomSpawnYIndex];

            string spawnMobName = stageMonsterList[randomSpawnMonsterIndex];
            PoolableMono spawnMob = PoolManager.Instance.Pop(spawnMobName, new Vector3(spawnPosX, spawnPosY), Quaternion.identity);

            // �ߺ� ����
            stageMonsterList[randomSpawnMonsterIndex] = stageMonsterList[i];
            spawnPosYList[randomSpawnYIndex] = spawnPosYList[i];    

        }


    }

}
