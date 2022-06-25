using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : PoolableMono
{
    [SerializeField] private float deletePosX = 9;
    [SerializeField] private float deleteMaxPosY = 5;
    [SerializeField] private float deleteMinPosY = -5;
    [SerializeField] private GameObject eggDestroy;
    private int bulletHp = 1;
    private bool bulletDestroyed = true;
    // Update is called once per frame
    void Update()
    {
        if(bulletDestroyed)
        {
            bulletHp = PlayerManager.Instance.Pierce;
            bulletDestroyed = false;
        }
        
        if (transform.position.x >= deletePosX || transform.position.y >= deleteMaxPosY || transform.position.y <= deleteMinPosY)
        {
            bulletDestroyed = true;
            PoolManager.Instance.Push(this);
        }

    }
    private void OnTriggerEnter2D(Collider2D obj)
    {
        if(obj.CompareTag("Enemy"))
        {
            EggDestroy eggDestroy = PoolManager.Instance.Pop("DestroyEgg") as EggDestroy;
            eggDestroy.transform.position = transform.position;
            bulletHp--;
            if(bulletHp <= 0)
            {
                bulletDestroyed = true;
                PoolManager.Instance.Push(this);
            }
        }
        
    }

    public override void Reset()
    {
        //
    }
}
