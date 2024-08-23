using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class MapGenerator : MonoBehaviour
{

    [SerializeField]
    private List<StageMonsterListSO> _spawnMobList;   
    // �ܰ躰�� ���� �� ������ ����?
    // 10������ ������ ���͵� �ܰ谡 �����ϰ� �� �̷� ����?
    // SO



    

    public void Generate()
    {

        EnemyGenerate();
        DisturbanceGenerate();

    }

    // 3���� 1 Ȯ���� ���ع� ����
    private void DisturbanceGenerate()
    {

        int currentScore = GameManager.Instance.GetScore();
        int index = currentScore / 10;
        if (index >= _spawnMobList.Count)
            index = _spawnMobList.Count - 1;

        StageMonsterListSO spawnMobList = _spawnMobList[index];
        List<PoolableMono> stageDangerObjectList = spawnMobList.StageDangerObjectList.ToList<PoolableMono>();

        if (stageDangerObjectList.Count <= 0)   // ��ȯ�� ���� ������Ʈ�� ���� �����̸� X
            return;

        float per = Random.Range(0f, 1f);
        if(per <= 0.33f)
        {

            // Create
            List<float> spawnPosYList = new List<float>() { -5.75f, -4.25f, -2.75f, -1.25f, -0.75f, 1.25f, 2.75f, 4.25f, 5.75f };

            int randomSpawnYIndex = Random.Range(0, spawnPosYList.Count);
            float spawnPosY = spawnPosYList[randomSpawnYIndex];

            string spawnDangerObjectName = stageDangerObjectList[Random.Range(0, stageDangerObjectList.Count)].name;
            DangerObject dangerObject = PoolManager.Instance.Pop("Danger", new Vector3(16.5f, spawnPosY), Quaternion.identity) as DangerObject;

            if (dangerObject != null)
            {

                dangerObject.Init(spawnDangerObjectName);

            }

        }



    }

    // �� ���� ���� �� �ϳ��� ����
    private void EnemyGenerate()
    {

        int currentScore = GameManager.Instance.GetScore();
        int index = currentScore / 10;
        if(index >= _spawnMobList.Count)
            index = _spawnMobList.Count - 1;

        StageMonsterListSO spawnMobList = _spawnMobList[index];
        List<SpawnMonsterData> stageMonsterList = spawnMobList.StageMonsterList[Random.Range(0, spawnMobList.StageMonsterList.Count)].Data.ToList<SpawnMonsterData>();

        List<float> spawnPosYList = new List<float>() { -5.75f, -4.25f, -2.75f, -1.25f, -0.75f, 1.25f, 2.75f, 4.25f, 5.75f };
        int spawnCount = 0;

        for (int i = 0; i < stageMonsterList.Count; i++)
        {

            SpawnMonsterData data = stageMonsterList[i];
            for(int j = 0; j < data.Count; ++j)
            {

                int randomSpawnYIndex = Random.Range(spawnCount, spawnPosYList.Count);
                float spawnPosX = Random.Range(19.5f, 20.5f);
                float spawnPosY = spawnPosYList[randomSpawnYIndex];

                string spawnMobName = data.Monster.name;
                PoolableMono spawnMob = PoolManager.Instance.Pop(spawnMobName, new Vector3(spawnPosX, spawnPosY), Quaternion.identity);

                spawnPosYList[randomSpawnYIndex] = spawnPosYList[spawnCount];    // �ߺ� ����
                spawnCount++;

            }

        }


    }

}
