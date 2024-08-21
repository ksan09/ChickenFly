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

        if (_spawnMobList.Count <= currentScore / 10) // 혹시 모를 예외처리
            return;

        StageMonsterListSO spawnMobList = _spawnMobList[currentScore / 10];
        List<PoolableMono> stageDangerObjectList = spawnMobList.StageDangerObjectList.ToList<PoolableMono>();

        if (stageDangerObjectList.Count <= 0)   // 소환할 위험 오브젝트가 없는 구간이면 X
            return;

        float per = Random.Range(0f, 1f);
        if(per <= 0.33f)
        {

            // Create
            List<int> spawnPosYList = new List<int>() { -6, -5, -4, -3, -2, -1, 0, 1, 2, 3, 4, 5 };

            int randomSpawnYIndex = Random.Range(0, spawnPosYList.Count);
            int spawnPosY = spawnPosYList[randomSpawnYIndex];

            string spawnDangerObjectName = stageDangerObjectList[Random.Range(0, stageDangerObjectList.Count)].name;
            DangerObject dangerObject = PoolManager.Instance.Pop("Danger", new Vector3(17, spawnPosY), Quaternion.identity) as DangerObject;

            if (dangerObject != null)
            {

                dangerObject.Init(spawnDangerObjectName);

            }

        }



    }

    // 적 생성
    private void EnemyGenerate()
    {

        int currentScore = GameManager.Instance.GetScore();

        StageMonsterListSO spawnMobList = _spawnMobList[currentScore / 10];
        List<PoolableMono> stageMonsterList = spawnMobList.StageMonsterList.ToList<PoolableMono>();
        int spawnCount = Random.Range(spawnMobList.MinSpawnCount, spawnMobList.MaxSpawnCount + 1);

        List<int> spawnPosYList = new List<int>() { -6, -5, -4, -3, -2, -1, 0, 1, 2, 3, 4, 5 };
        for (int i = 0; i < spawnCount; i++)
        {

            int randomSpawnYIndex = Random.Range(i, spawnPosYList.Count);
            int spawnPosY = spawnPosYList[randomSpawnYIndex];

            string spawnMobName = stageMonsterList[Random.Range(0, stageMonsterList.Count)].name;
            PoolableMono spawnMob = PoolManager.Instance.Pop(spawnMobName, new Vector3(20, spawnPosY), Quaternion.identity);

            spawnPosYList[randomSpawnYIndex] = spawnPosYList[i];    // 중복 제거

        }


    }

}
