using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingBullet : PoolableMono
{
    [SerializeField] private GameObject eggDestroy;
    private GameObject target;
    Vector2 dir;
    private bool bulletDestroyed = true;
    private float speed = 5;
    // Update is called once per frame
    void Update()
    {
        DieCheck();
        Move();
    }
    private void EnemyCheck()
    {
        target = GameObject.FindGameObjectWithTag("Enemy");
    }
    private void Move()
    {
        if(target != null && target.activeInHierarchy && target.transform.position.x >= -8.5f && target.transform.position.x <= 8.5f && target.transform.position.y >= -4.5f && target.transform.position.y <= 4.5f)
        {
            Debug.Log("°¨Áö Àß µÊ");
            //if(transform.rotation.y < 180)
                dir = target.transform.position - transform.position;
            //else
            //{
            //    dir.x = transform.position.x - target.transform.position.x;
            //    dir.y = target.transform.position.y - transform.position.y;
            //}
                
            dir.Normalize();
        }
        else
        {
            Debug.Log("°¨Áö ¾ÈµÊ");
            dir = new Vector3(1, 0, 0);
            EnemyCheck();
        }
        
        transform.Translate(dir * speed * Time.deltaTime);
    }
    private void DieCheck()
    {
        if (transform.position.x >= 10 || transform.position.y >= 5.5f || transform.position.y <= -5.5f || transform.position.x <= -10)
        {
            bulletDestroyed = true;
            PoolManager.Instance.Push(this);
        }
        if (bulletDestroyed)
        {
            bulletDestroyed = false;
            EnemyCheck();
        }
    }
    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.CompareTag("Enemy"))
        {
            EggDestroy eggDestroy = PoolManager.Instance.Pop("DestroyEgg") as EggDestroy;
            eggDestroy.transform.position = transform.position;
            bulletDestroyed = true;
            PoolManager.Instance.Push(this);
        }
        
    }

    public override void Reset()
    {
        //
    }
}
