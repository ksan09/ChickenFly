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

        // �����
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

        // ī�� ���� ����
        _playerStat.AddPlayerStat(card.CardEffect.CardStatInfo);

        // card effect
        foreach (var cardEffect in card.CardEffect.CardEffectList)
        {

            cardEffect.UseCardEffect(card);

        }

        // Counting
        _playerCardCount[card]++;
        OnObtainCardEvent?.Invoke(card);

        // ī�尡 �ְ� ������ �����ߴٸ�
        if (_playerCardCount[card] == card.CardMaxLevel)
        {

            // �� �̻� �ش� ī�尡 ������ �ʵ��� ó��


        }

        UpdatePlayerStatUI();

    }

    // Editor ������
    [Header("�����")]
    public TextMeshProUGUI PlayerStatUI;

    public void UpdatePlayerStatUI()
    {

        PlayerStatData playerStatData = _playerStat.GetPlayerStatData();

        PlayerStatUI.text = $"<size=48>�÷��̾� ����</size>"
                    + $"\nü��: {playerStatData.MaxHealth}"     
                    + $"\n���ݷ�: {playerStatData.Strength}" 
                    + $"\n�ʴ� ���ݼӵ�: {playerStatData.AttackSpeed}"      
                    + $"\n����: {playerStatData.Defense}"      
                    + $"\n�ӵ�: {playerStatData.Speed}"     
                    + $"\n���: {playerStatData.Luck}"      
                    + $"\n����_���: {playerStatData.CurseLuck}"     
                    + $"\n�� óġ �� ȸ����: {playerStatData.HealValue}"      
                    + $"\n���� �Ŀ�: {playerStatData.JumpPower}"      
                    + $"\n�ڼ�: {playerStatData.Magnet}"      
                    + $"\n�ǹ� ���ӽð�: {playerStatData.FeverDuration}"      
                    + $"\n���ݷ� ����: {playerStatData.StrengthPer * 100}%"      
                    + $"\n�߰� �ǰ� ������: {playerStatData.HitDamageAmountPer * 100}%"      
                    + $"\n��ų ��ٿ�: {playerStatData.SkillCoolDownPer * 100}%"      
                    + $"\n����� ���: {playerStatData.LifeDrainPer * 100}%"      
                    + $"\n����ġ ȹ�淮: {playerStatData.ExpPer * 100}%"      
                    + $"\n��� ȹ�淮: {playerStatData.GoldPer*100}%"                    
                    + $"\n�������� �ӵ� ����: {playerStatData.FallSpeedPer*100}%"             
                    + $"\n����: {playerStatData.ShotGunEgg}"                  
                    + $"\n����: {playerStatData.Through}"                     
                    + $"\n��Ȱ: {playerStatData.Life}";



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
