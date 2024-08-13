using System;
using System.Collections;
using System.Collections.Generic;
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

        int currentScore = GameManager.Instance.GetScore();

        StageMonsterListSO spawnMobList = _spawnMobList[currentScore / 10];
        List<PoolableMono> stageMonsterList = spawnMobList.StageMonsterList;
        int spawnCount = Random.Range(spawnMobList.MinSpawnCount, spawnMobList.MaxSpawnCount + 1);

        List<int> spawnPosYList = new List<int>() { -7, -6, -5, -4, -3, -2, -1, 0, 1, 2, 3, 4, 5, 6, 7 };
        for(int i = 0; i < spawnCount; i++)
        {

            int randomSpawnYIndex = Random.Range(i, spawnPosYList.Count);
            int spawnPosY = spawnPosYList[randomSpawnYIndex];

            string spawnMobName = stageMonsterList[Random.Range(0, stageMonsterList.Count)].name;
            PoolableMono spawnMob = PoolManager.Instance.Pop(spawnMobName, new Vector3(20, spawnPosY), Quaternion.identity);

            spawnPosYList[randomSpawnYIndex] = spawnPosYList[i];    // 중복 제거

        }

    }

}
