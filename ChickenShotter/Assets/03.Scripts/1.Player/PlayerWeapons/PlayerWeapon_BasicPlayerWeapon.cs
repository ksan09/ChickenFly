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
        PlayerBullet spanwBullet = PoolManager.Instance.Pop("PlayerBasicBullet", _firePos.position, Quaternion.identity) as PlayerBullet;
        spanwBullet.Shoot(Vector2.right);



    }

}
