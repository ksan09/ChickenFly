using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : PoolableMono
{
    [SerializeField] private float deletePosX = 9;
    [SerializeField] private float deleteMaxPosY = 5;
    [SerializeField] private float deleteMinPosY = -5;
    [SerializeField] private GameObject eggDestroy;
    private int bulletHp;
    // Update is called once per frame
    private void Start()
    {
        bulletHp = PlayerManager.Instance.Pierce;
    }
    void Update()
    {
        if (transform.position.x >= deletePosX || transform.position.y >= deleteMaxPosY || transform.position.y <= deleteMinPosY)
            PoolManager.Instance.Push(this);

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
                PoolManager.Instance.Push(this);
            }
        }
        
    }

    public override void Reset()
    {
        //
    }
}
