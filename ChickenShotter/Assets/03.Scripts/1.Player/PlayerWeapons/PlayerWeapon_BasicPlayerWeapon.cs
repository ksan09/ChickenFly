using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon_BasicPlayerWeapon : PlayerWeapon
{

    [Header("Info")]
    [SerializeField] private Transform _firePos;

    

    public override void Attack()
    {

        // Spawn Bullet

        if(_shotGunEgg > 0)
        {
            for (int i = 0; i <= (_shotGunEgg * 2); ++i) // 0, 1, 2
            {

                float startAngle = 15f;
                float curAngle = startAngle - (30f / (_shotGunEgg * 2)) * i;

                Vector2 dir = new Vector2(Mathf.Cos(curAngle * Mathf.Deg2Rad), Mathf.Sin(curAngle * Mathf.Deg2Rad));

                PlayerBullet bullet = PoolManager.Instance.Pop("PlayerBasicBullet", _firePos.position, Quaternion.identity) as PlayerBullet;
                bullet.Shoot(dir, curAngle);

            }

            return;

        }

        PlayerBullet spanwBullet = PoolManager.Instance.Pop("PlayerBasicBullet", _firePos.position, Quaternion.identity) as PlayerBullet;
        spanwBullet.Shoot(Vector2.right);

    }

}
