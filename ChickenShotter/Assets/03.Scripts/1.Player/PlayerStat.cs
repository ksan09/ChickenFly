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

    // Exp
    private PlayerLevelData _playerLevelData;   // 각 레벨마다 필요한 경험치 값이 들어가 있다.
    private int _currentLevel = 0;
    private float _exp;

    // umm.. this part is bad code
    private Coroutine _hitEffectCoroutine;
    private WaitForSecondsRealtime _wfsrHitTime;

    private Material _playerMaterial;
    private readonly int HASH_BLINK = Shader.PropertyToID("_StrongTintFade");
    private readonly int HASH_SHAKE = Shader.PropertyToID("_VibrateFade");

    public event OnUpdatePlayerStatDataDelegate OnUpdatePlayerStat;

    private void Awake()
    {

        _playerStatData = _playerStatDataSO.StatData;

        _healthObject = GetComponent<HealthObject>();
        _healthObject.Init(_playerStatData.MaxHealth);

        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if(sprite != null)
            _playerMaterial = sprite.material;

        _wfsrHitTime = new WaitForSecondsRealtime(0.1f);

        _healthObject.OnHitEvent += HandleHitEffect;

        OnUpdatePlayerStat += HandleUpdatePlayerStat;

    }


    public void AddPlayerStat(CardAddStatInfo info)
    {

        PlayerStatData lastData = _playerStatData;

        // 스탯
        _playerStatData.MaxHealth           += info.Health;
        _playerStatData.Strength            += info.Strength;
        _playerStatData.AttackSpeed         += info.AttackSpeed;
        _playerStatData.Defense             += info.Defense;
        _playerStatData.Speed               += info.Speed;
        _playerStatData.Luck                += info.Luck;
        _playerStatData.CurseLuck           += info.CurseLuck;
        _playerStatData.HealValue           += info.HealValue;
        _playerStatData.JumpPower           += info.JumpPower;
        _playerStatData.Magnet              += info.Magnet;
        _playerStatData.FeverDuration       += info.FeverDuration;

        // 퍼센트 스탯
        _playerStatData.StrengthPer         += info.StrengthPer;
        _playerStatData.HitDamageAmountPer  += info.HitDamageAmountPer;
        _playerStatData.SkillCoolDownPer    += info.SkillCoolDownPer;
        _playerStatData.LifeDrainPer        += info.LifeDrainPer;
        _playerStatData.ExpPer              += info.ExpPer;
        _playerStatData.GoldPer             += info.GoldPer;
        _playerStatData.FallSpeedPer        += info.FallSpeedPer;

        // 레벨 스탯
        _playerStatData.ShotGunEgg          += info.ShotGunEgg;
        _playerStatData.Through             += info.Through;
        _playerStatData.Life                += info.Life;

        OnUpdatePlayerStat?.Invoke(lastData, _playerStatData);

    }
    public void RemovePlayerStat(CardAddStatInfo info)
    {

        PlayerStatData lastData = _playerStatData;

        // 스탯
        _playerStatData.MaxHealth           -= info.Health;
        _playerStatData.Strength            -= info.Strength;
        _playerStatData.AttackSpeed         -= info.AttackSpeed;
        _playerStatData.Defense             -= info.Defense;
        _playerStatData.Speed               -= info.Speed;
        _playerStatData.Luck                -= info.Luck;
        _playerStatData.CurseLuck           -= info.CurseLuck;
        _playerStatData.HealValue           -= info.HealValue;
        _playerStatData.JumpPower           -= info.JumpPower;
        _playerStatData.Magnet              -= info.Magnet;
        _playerStatData.FeverDuration       -= info.FeverDuration;

        // 퍼센트 스탯
        _playerStatData.StrengthPer         -= info.StrengthPer;
        _playerStatData.HitDamageAmountPer  -= info.HitDamageAmountPer;
        _playerStatData.SkillCoolDownPer    -= info.SkillCoolDownPer;
        _playerStatData.LifeDrainPer        -= info.LifeDrainPer;
        _playerStatData.ExpPer              -= info.ExpPer;
        _playerStatData.GoldPer             -= info.GoldPer;
        _playerStatData.FallSpeedPer        -= info.FallSpeedPer;

        // 레벨 스탯
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

    private void HandleHitEffect()
    {

        CameraManager.Instance.ShakeCam(4f, 2f);

        PoolingParticle poolingParticle = 
            PoolManager.Instance.Pop("PlayerHitParticle", transform.position, Quaternion.identity) as PoolingParticle;

        if (poolingParticle != null)
        {

            poolingParticle.PlayParticle();

        }

        //

        if (_hitEffectCoroutine != null)
            StopCoroutine(_hitEffectCoroutine);

        _hitEffectCoroutine = StartCoroutine(HitEffectCo());

    }

    IEnumerator HitEffectCo()
    {

        _playerMaterial.SetFloat(HASH_BLINK, 1f);
        _playerMaterial.SetFloat(HASH_SHAKE, 1f);
        TimeManager.Instance.SetTime(0.1f);

        yield return _wfsrHitTime;

        _playerMaterial.SetFloat(HASH_BLINK, 0f);
        _playerMaterial.SetFloat(HASH_SHAKE, 0f);
        _hitEffectCoroutine = null;
        TimeManager.Instance.SetTime(1f);

    }

}
