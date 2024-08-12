using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerWeapon : MonoBehaviour
{

    // �Ѿ� �߻�
    private float _attackSpeed;       // �ʴ� ���ݼӵ�
    private int _shotGunEgg;          // ����
    private int _through;             // ����

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
