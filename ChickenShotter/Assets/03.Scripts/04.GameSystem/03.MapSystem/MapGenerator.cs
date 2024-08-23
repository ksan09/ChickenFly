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
    // 단계별로 점점 더 쎄지는 느낌?
    // 10점마다 나오는 몬스터들 단계가 증가하고 뭐 이런 저런?
    // SO



    

    public void Generate()
    {

        EnemyGenerate();
        DisturbanceGenerate();

    }

    // 3분의 1 확률로 방해물 생성
    private void DisturbanceGenerate()
    {

        int currentScore = GameManager.Instance.GetScore();
        int index = currentScore / 10;
        if (index >= _spawnMobList.Count)
            index = _spawnMobList.Count - 1;

        StageMonsterListSO spawnMobList = _spawnMobList[index];
        List<PoolableMono> stageDangerObjectList = spawnMobList.StageDangerObjectList.ToList<PoolableMono>();

        if (stageDangerObjectList.Count <= 0)   // 소환할 위험 오브젝트가 없는 구간이면 X
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

    // 적 생성 패턴 중 하나로 생성
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

                spawnPosYList[randomSpawnYIndex] = spawnPosYList[spawnCount];    // 중복 제거
                spawnCount++;

            }

        }


    }

}
