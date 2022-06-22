using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialStage : MonoBehaviour
{
    [SerializeField] private string eBullet;

    [SerializeField] float maxSpawnTime;
    [SerializeField] float minSpawnTime;
    [SerializeField] private float spawnPosX = 10;
    [SerializeField] private float maxPosY = 4.5f;
    [SerializeField] private float minPosY = -5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBullet());
    }

    IEnumerator SpawnBullet()
    {
        while (true)
        {
            float rd = Random.Range(0f, 10f);
            if(rd <= 2)
            {
                for(int i = 0; i < 5; i++)
                {
                    EnemyBullet enemyBullet = PoolManager.Instance.Pop(eBullet) as EnemyBullet;
                    enemyBullet.transform.position = new Vector3(spawnPosX, maxPosY - i);
                }
            }
            else if(rd <= 3)
            {
                for (int i = 0; i < 5; i++)
                {
                    EnemyBullet enemyBullet = PoolManager.Instance.Pop(eBullet) as EnemyBullet;
                    enemyBullet.transform.position = new Vector3(spawnPosX, minPosY + i);
                }
            }
            else if (rd <= 4)
            {
                for (int i = 0; i < 3; i++)
                {
                    EnemyBullet enemyBullet = PoolManager.Instance.Pop(eBullet) as EnemyBullet;
                    enemyBullet.transform.position = new Vector3(spawnPosX, maxPosY - i);
                }
                for (int i = 0; i < 2; i++)
                {
                    EnemyBullet enemyBullet = PoolManager.Instance.Pop(eBullet) as EnemyBullet;
                    enemyBullet.transform.position = new Vector3(spawnPosX, minPosY + i);
                }
            }
            else if (rd <= 5)
            {
                for (int i = 0; i < 3; i++)
                {
                    EnemyBullet enemyBullet = PoolManager.Instance.Pop(eBullet) as EnemyBullet;
                    enemyBullet.transform.position = new Vector3(spawnPosX, minPosY + i);
                }
                for (int i = 0; i < 2; i++)
                {
                    EnemyBullet enemyBullet = PoolManager.Instance.Pop(eBullet) as EnemyBullet;
                    enemyBullet.transform.position = new Vector3(spawnPosX, maxPosY - i);
                }
            }
            else if (rd <= 8)
            {
                for (int i = 0; i < 1; i++)
                {
                    EnemyBullet enemyBullet = PoolManager.Instance.Pop(eBullet) as EnemyBullet;
                    enemyBullet.transform.position = new Vector3(spawnPosX, minPosY + i);
                }
                for (int i = 0; i < 4; i++)
                {
                    EnemyBullet enemyBullet = PoolManager.Instance.Pop(eBullet) as EnemyBullet;
                    enemyBullet.transform.position = new Vector3(spawnPosX, maxPosY - i);
                }
            }
            else if (rd <= 9)
            {
                for (int i = 0; i < 4; i++)
                {
                    EnemyBullet enemyBullet = PoolManager.Instance.Pop(eBullet) as EnemyBullet;
                    enemyBullet.transform.position = new Vector3(spawnPosX, minPosY + i);
                }
                for (int i = 0; i < 1; i++)
                {
                    EnemyBullet enemyBullet = PoolManager.Instance.Pop(eBullet) as EnemyBullet;
                    enemyBullet.transform.position = new Vector3(spawnPosX, maxPosY - i);
                }
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    EnemyBullet enemyBullet = PoolManager.Instance.Pop(eBullet) as EnemyBullet;
                    enemyBullet.transform.position = new Vector3(spawnPosX, minPosY + i);
                }
                for (int i = 0; i < 2; i++)
                {
                    EnemyBullet enemyBullet = PoolManager.Instance.Pop(eBullet) as EnemyBullet;
                    enemyBullet.transform.position = new Vector3(spawnPosX, maxPosY - i);
                }
            }
            float spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(spawnTime);
        }
        
    }
}
