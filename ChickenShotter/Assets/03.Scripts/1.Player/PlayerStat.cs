using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnUpdatePlayerStatDataDelegate(PlayerStatData lastData, PlayerStatData currentData);

public class PlayerStat : MonoBehaviour
{

    [SerializeField]
    private PlayerStatDataSO _playerStatDataSO;
    private PlayerStatData _playerStatData;

    private HealthObject _healthObject;

    public event OnUpdatePlayerStatDataDelegate OnUpdatePlayerStat;

    private void Awake()
    {

        _playerStatData = _playerStatDataSO.StatData;

        _healthObject = GetComponent<HealthObject>();
        _healthObject.Init(_playerStatData.MaxHealth);

        OnUpdatePlayerStat += HandleUpdatePlayerStat;

    }

    public void AddPlayerStat(CardAddStatInfo info)
    {

        PlayerStatData lastData = _playerStatData;

        // ½ºÅÈ
        _playerStatData.MaxHealth           += info.Health;
        _playerStatData.Strength            += info.Strength;
        _playerStatData.AttackSpeed         += info.AttackSpeed;
        _playerStatData.Defense             += info.Defense;
        _playerStatData.Speed               += info.Speed;
        _playerStatData.Luck                += info.Luck;
        _playerStatData.CurseLuck           += info.CurseLuck;
        _playerStatData.Digestion           += info.Digestion;
        _playerStatData.JumpPower           += info.JumpPower;
        _playerStatData.Magnet              += info.Magnet;
        _playerStatData.FeverDuration       += info.FeverDuration;

        // ÆÛ¼¾Æ® ½ºÅÈ
        _playerStatData.StrengthPer         += info.StrengthPer;
        _playerStatData.HitDamageAmountPer  += info.HitDamageAmountPer;
        _playerStatData.SkillCoolDownPer    += info.SkillCoolDownPer;
        _playerStatData.LifeDrainPer        += info.LifeDrainPer;
        _playerStatData.ExpPer              += info.ExpPer;
        _playerStatData.GoldPer             += info.GoldPer;
        _playerStatData.FallSpeedPer        += info.FallSpeedPer;

        // ·¹º§ ½ºÅÈ
        _playerStatData.ShotGunEgg          += info.ShotGunEgg;
        _playerStatData.Through             += info.Through;
        _playerStatData.Life                += info.Life;

        OnUpdatePlayerStat?.Invoke(lastData, _playerStatData);

    }
    public void RemovePlayerStat(CardAddStatInfo info)
    {

        PlayerStatData lastData = _playerStatData;

        // ½ºÅÈ
        _playerStatData.MaxHealth           -= info.Health;
        _playerStatData.Strength            -= info.Strength;
        _playerStatData.AttackSpeed         -= info.AttackSpeed;
        _playerStatData.Defense             -= info.Defense;
        _playerStatData.Speed               -= info.Speed;
        _playerStatData.Luck                -= info.Luck;
        _playerStatData.CurseLuck           -= info.CurseLuck;
        _playerStatData.Digestion           -= info.Digestion;
        _playerStatData.JumpPower           -= info.JumpPower;
        _playerStatData.Magnet              -= info.Magnet;
        _playerStatData.FeverDuration       -= info.FeverDuration;

        // ÆÛ¼¾Æ® ½ºÅÈ
        _playerStatData.StrengthPer         -= info.StrengthPer;
        _playerStatData.HitDamageAmountPer  -= info.HitDamageAmountPer;
        _playerStatData.SkillCoolDownPer    -= info.SkillCoolDownPer;
        _playerStatData.LifeDrainPer        -= info.LifeDrainPer;
        _playerStatData.ExpPer              -= info.ExpPer;
        _playerStatData.GoldPer             -= info.GoldPer;
        _playerStatData.FallSpeedPer        -= info.FallSpeedPer;

        // ·¹º§ ½ºÅÈ
        _playerStatData.ShotGunEgg          -= info.ShotGunEgg;
        _playerStatData.Through             -= info.Through;
        _playerStatData.Life                -= info.Life;

        OnUpdatePlayerStat?.Invoke(lastData, _playerStatData);

    }

    public PlayerStatData GetPlayerStatData() => _playerStatData;

    private void HandleUpdatePlayerStat(PlayerStatData lastData, PlayerStatData currentData)
    {

        _healthObject.ChangeMaxHealth(currentData.MaxHealth);

    }

}
