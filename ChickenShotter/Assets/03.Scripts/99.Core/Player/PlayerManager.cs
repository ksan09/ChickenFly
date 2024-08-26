using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

// Player Delegate
public delegate void OnPlayerAttackEventDelegate(Transform hitObj);                 // Player Attack Effect
                                                                                    // ex: Hit Explosion
public delegate void OnPlayerHitEventDelegate(Transform attackObj);                 // Player Hit Effect
                                                                                    // ex: Reflect Damage
                                                                                                                                                       //
public delegate float OnCalculateAddPlayerAttackDamageDelegate(PlayerStatData stat);    // Calc Add Player Damage
                                                                                        // ex: Add Damage Player's Defense 50%
                                                                                        //
public delegate float OnCalculateAddPlayerHitDamageDelegate(PlayerStatData stat);       // Calc Player Hit Damage

public class PlayerManager : MonoSingleton<PlayerManager>
{

    private Dictionary<CardInfoSO, int> _playerCardCount;   // Player Card's Count
    private int _playerCurrentCardCount = 0;                // Player Card Count

    public PlayerCardSkillData CardSkillData { get; set; }

    [Header("Player")]
    [SerializeField]
    private Transform _playerTrm;
    private PlayerStat _playerStat;                         // Player Stat
    private PlayerLevel _playerLevel;                       // Player Level
    private HealthObject _playerHealth;                     // Player Health

    public event OnPlayerAttackEventDelegate            OnPlayerAttackEvent;            // Player Attack Effect
    public event OnPlayerHitEventDelegate               OnPlayerHitEvent;               // Player Hit Effect
    public event OnCalculateAddPlayerAttackDamageDelegate  OnCalculatePlayerAttackDamage;  // Calc Add Player Damage
    public event OnCalculateAddPlayerHitDamageDelegate     OnCalculatePlayerHitDamage;     // Calc Player Hit Damage

    public event Action<Transform> OnKillEnemyEvent;

    public event Action<CardInfoSO> OnObtainCardEvent;
    public event Action<CardInfoSO> OnRemoveCardEvent;

    public override void Init()
    {

        CardSkillData = new PlayerCardSkillData();

        if (_playerTrm == null)
            _playerTrm = GameObject.Find("Player").transform;

        if (_playerTrm != null)
        {

            _playerStat = _playerTrm.GetComponent<PlayerStat>();
            _playerHealth = _playerTrm.GetComponent<HealthObject>();
            _playerLevel = _playerTrm.GetComponent<PlayerLevel>();

        }

        SetCardData(CardManager.Instance.CardList);
        _playerCurrentCardCount = 0;

        // 디버깅
        UpdatePlayerStatUI();

    }

    public void SetCardData(List<CardInfoSO> cardList)
    {

        _playerCardCount = new Dictionary<CardInfoSO, int>();
        foreach (CardInfoSO card in cardList)
        {

            _playerCardCount.Add(card, 0);

        }

    }
    public void ObtainCard(CardInfoSO card)
    {

        // 카드 스탯 적용
        _playerStat.AddPlayerStat(card.CardEffect.CardStatInfo);

        // card effect
        foreach (var cardEffect in card.CardEffect.CardEffectList)
        {

            cardEffect.UseCardEffect(card);

        }

        // Counting
        _playerCardCount[card]++;
        OnObtainCardEvent?.Invoke(card);

        // 카드가 최고 레벨에 도달했다면
        if (_playerCardCount[card] == card.CardMaxLevel)
        {

            // 더 이상 해당 카드가 나오지 않도록 처리


        }

        UpdatePlayerStatUI();

    }

    // Editor 디버깅용
    [Header("디버깅")]
    public TextMeshProUGUI PlayerStatUI;

    public void UpdatePlayerStatUI()
    {

        PlayerStatData playerStatData = _playerStat.GetPlayerStatData();

        PlayerStatUI.text = $"<size=48>플레이어 스탯</size>"
                    + $"\n체력: {playerStatData.MaxHealth}"     
                    + $"\n공격력: {playerStatData.Strength}" 
                    + $"\n초당 공격속도: {playerStatData.AttackSpeed}"      
                    + $"\n방어력: {playerStatData.Defense}"      
                    + $"\n속도: {playerStatData.Speed}"     
                    + $"\n행운: {playerStatData.Luck}"      
                    + $"\n저주_행운: {playerStatData.CurseLuck}"     
                    + $"\n적 처치 시 회복량: {playerStatData.HealValue}"      
                    + $"\n점프 파워: {playerStatData.JumpPower}"      
                    + $"\n자석: {playerStatData.Magnet}"      
                    + $"\n피버 지속시간: {playerStatData.FeverDuration}"      
                    + $"\n공격력 증가: {playerStatData.StrengthPer * 100}%"      
                    + $"\n추가 피격 데미지: {playerStatData.HitDamageAmountPer * 100}%"      
                    + $"\n스킬 쿨다운: {playerStatData.SkillCoolDownPer * 100}%"      
                    + $"\n생명력 흡수: {playerStatData.LifeDrainPer * 100}%"      
                    + $"\n경험치 획득량: {playerStatData.ExpPer * 100}%"      
                    + $"\n골드 획득량: {playerStatData.GoldPer*100}%"                    
                    + $"\n떨어지는 속도 증가: {playerStatData.FallSpeedPer*100}%"             
                    + $"\n샷건: {playerStatData.ShotGunEgg}"                  
                    + $"\n관통: {playerStatData.Through}"                     
                    + $"\n부활: {playerStatData.Life}";



    }

    public void RemoveCard(CardInfoSO card)
    {

        if (_playerCardCount.ContainsKey(card) == false ||
            _playerCardCount[card] == 0)
            return;

        _playerStat.RemovePlayerStat(card.CardEffect.CardStatInfo);

        foreach (var cardEffect in card.CardEffect.CardEffectList)
        {

            cardEffect.RemoveCardEffect(card);

        }

        // Counting
        _playerCardCount[card]--;
        OnRemoveCardEvent?.Invoke(card);


    }
    public void RemoveAllCard()
    {

        foreach (var playerCardCount in _playerCardCount)
        {

            while(playerCardCount.Value > 0)
            {

                RemoveCard(playerCardCount.Key);

            }

        }

    }

    public int GetCurrentPlayerCardCount()                                  => _playerCurrentCardCount;
    public int GetCurrentCardCount(CardInfoSO card)                         => _playerCardCount[card];
    public Dictionary<CardInfoSO, int> GetPlayerCardCountDictionary()       => _playerCardCount;
    public Transform GetPlayerTransform()                                   => _playerTrm;
    public PlayerStat GetPlayerStat()                                       => _playerStat;
    public PlayerLevel GetPlayerLevel()                                     => _playerLevel;
    public HealthObject GetPlayerHealth()                                   => _playerHealth;

    public void KillEnemy(Transform deathEnemyTrm)
    {

        OnKillEnemyEvent?.Invoke(deathEnemyTrm);

    }
    public void CallPlayerAttackEvent(Transform enemyTrm)
    {
        OnPlayerAttackEvent?.Invoke(enemyTrm);
    }

    public float CalcPlayerDamage()
    {

        PlayerStatData data = _playerStat.GetPlayerStatData();
        float damage = data.Strength * data.StrengthPer;

        if (OnCalculatePlayerAttackDamage == null)
        {

            _playerHealth.AddHealth(damage * _playerStat.GetPlayerStatData().LifeDrainPer);
            return damage;

        }

        foreach(OnCalculateAddPlayerAttackDamageDelegate calcPlayerAttackDamageDelegate 
            in OnCalculatePlayerAttackDamage.GetInvocationList())
        {

            if (calcPlayerAttackDamageDelegate == null)
                continue;

            damage += calcPlayerAttackDamageDelegate.Invoke(data);

        }

        _playerHealth.AddHealth(damage * _playerStat.GetPlayerStatData().LifeDrainPer);
        return damage;

    }
    public float CalcPlayerHitDamage(float damage)
    {

        PlayerStatData data = _playerStat.GetPlayerStatData();
        damage = data.HitDamageAmountPer * damage;

        if (OnCalculatePlayerHitDamage == null)
            return damage;

        foreach (OnCalculateAddPlayerHitDamageDelegate calcPlayerHitDamageDelegate
            in OnCalculatePlayerHitDamage.GetInvocationList())
        {

            if (calcPlayerHitDamageDelegate == null)
                continue;

            damage += calcPlayerHitDamageDelegate.Invoke(data);

        }

        return damage;

    }

}
