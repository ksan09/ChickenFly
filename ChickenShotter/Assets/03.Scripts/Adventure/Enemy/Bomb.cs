using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : PoolableMono
{
    float rd;
    bool spawn = false;
    private mateo m;
    public override void Reset()
    {
        
    }
    private void Start()
    {
        m=GetComponent<mateo>();
        rd = Random.Range(-4.5f, 2f);
    }
    void Update()
    {
        if(transform.position.y >= 4)
            spawn = true;
        if(transform.position.y < rd && spawn)
        {
            for (int i = 0; i < 8; i++)
            {
                EnemyBullet enemyBullet = PoolManager.Instance.Pop("EnemyBullet") as EnemyBullet;
                enemyBullet.transform.position = transform.position;
                enemyBullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, i * 45));
            }
            PoolManager.Instance.Push(m);
        }
        
    }
}
