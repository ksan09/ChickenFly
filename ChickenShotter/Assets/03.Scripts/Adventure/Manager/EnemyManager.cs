using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private float spawnMaxTime;
    [SerializeField] private float spawnMinTime;
    
    [SerializeField] private float spawnSpeed = 0f;
    private float currentTime = 0f;
    private float fastSpawnSpeed = 0f;
    private float randomPosY;
    [SerializeField] private float PosX;
    private int randomPattern;
    [SerializeField] private string mPrefab;
    [SerializeField] private string mFastPrefab;
    [SerializeField] private string mHeavyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("monsterSpawnLoop");
        StartCoroutine("fastMonsterSpawn");
    }

    IEnumerator fastMonsterSpawn()
    {
        while(true)
        {
            randomPosY = Random.Range(-5f, 5f);
            Danger mFast = PoolManager.Instance.Pop(mFastPrefab) as Danger;
            mFast.transform.position = new Vector3(PosX - 2f, randomPosY, 0);
            fastSpawnSpeed = Random.Range(spawnMinTime, spawnMaxTime);
            yield return new WaitForSeconds(fastSpawnSpeed);
        }
    }

    IEnumerator monsterSpawnLoop()
    {
        while(true)
        {
            currentTime += Time.deltaTime;
            if (spawnSpeed <= currentTime)
            {
                randomPosY = Random.Range(-5f, 5f);
                randomPattern = Random.Range(0, 100);
                if (randomPattern <= 20)
                {
                    for (int i = 0; i < 3; i++)
                        for (int j = 0; j < 2; j++)
                        {
                            Enemy m = PoolManager.Instance.Pop(mPrefab) as Enemy;
                            m.transform.position = new Vector3(PosX + i, randomPosY - j, 0);
                        }

                }
                else if (randomPattern <= 40)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        Enemy mHeavy = PoolManager.Instance.Pop(mHeavyPrefab) as Enemy;
                        mHeavy.transform.position = new Vector3(PosX, randomPosY - i * 2 + 4, 0);
                        
                    }
                }
                else if (randomPattern <= 50)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        Enemy mHeavy = PoolManager.Instance.Pop(mHeavyPrefab) as Enemy;
                        mHeavy.transform.position = new Vector3(PosX + i, randomPosY, 0);
                        
                    }

                }
                else if (randomPattern <= 70)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        Enemy m = PoolManager.Instance.Pop(mPrefab) as Enemy;
                        m.transform.position = new Vector3(PosX + i, randomPosY, 0);
                    }

                }
                else
                {
                    for (int j = 0; j < 2; j++)
                    {
                        randomPosY = Random.Range(-5f, 5f);
                        Enemy m = PoolManager.Instance.Pop(mPrefab) as Enemy;
                        m.transform.position = new Vector3(PosX + j * 1.5f, randomPosY, 0);
                        Enemy mHeavy = PoolManager.Instance.Pop(mHeavyPrefab) as Enemy;
                        mHeavy.transform.position = new Vector3(PosX + j * 3f, randomPosY, 0);
                    }
                }
                currentTime = 0;
                spawnSpeed = Random.Range(spawnMinTime, spawnMaxTime);
                yield return new WaitForSeconds(spawnSpeed);


            }
        }
    }
}
