using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerWeapon : MonoBehaviour
{

    // 총알 발사
    private float _attackSpeed;       // 초당 공격속도
    private int _shotGunEgg;          // 샷건
    private int _through;             // 관통

    protected virtual void Awake()
    {

        PlayerManager.Instance.GetPlayerStat().OnUpdatePlayerStat += HandleUpdatePlayerWeaponWhenUpdatedPlayerStat;

    }

    protected void HandleUpdatePlayerWeaponWhenUpdatedPlayerStat(PlayerStatData lastData, PlayerStatData currentData)
    {

        _attackSpeed     = currentData.AttackSpeed;

        _shotGunEgg      = currentData.ShotGunEgg;
        _through         = currentData.Through;

    }

    public abstract void Attack();

}
