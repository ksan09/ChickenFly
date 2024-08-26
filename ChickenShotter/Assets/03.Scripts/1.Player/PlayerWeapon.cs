using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerWeapon : MonoBehaviour
{

    // �Ѿ� �߻�
    protected float _attackSpeed;       // �ʴ� ���ݼӵ�
    protected int _shotGunEgg;          // ����
    protected int _through;             // ����

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
