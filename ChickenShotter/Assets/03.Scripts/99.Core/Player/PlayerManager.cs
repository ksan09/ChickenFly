using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// Player Delegate
public delegate void OnPlayerAttackEventDelegate(Transform hitObj);                 // Player Attack Effect
                                                                                    // ex: Hit Explosion
public delegate void OnPlayerHitEventDelegate(Transform attackObj);                 // Player Hit Effect
                                                                                    // ex: Reflect Damage
                                                                                                                                                       //
public delegate float OnCalculatePlayerAttackDamageDelegate(PlayerStatData stat);   // Calc Add Player Damage
                                                                                    // ex: Add Damage Player's Defense 50%
                                                                                    //
public delegate float OnCalculatePlayerHitDamageDelegate(PlayerStatData stat);      // Calc Player Hit Damage

public class PlayerManager : MonoSingleton<PlayerManager>
{

    private Dictionary<CardInfoSO, int> _playerCardCount;   // Player Card's Count
    private int _playerCurrentCardCount = 0;                // Player Card Count

    [Header("Player")]
    [SerializeField]
    private Transform _playerTrm;
    private PlayerStat _playerStat;                         // Player Stat

    public event OnPlayerAttackEventDelegate            OnPlayerAttackEvent;            // Player Attack Effect
    public event OnPlayerHitEventDelegate               OnPlayerHitEvent;               // Player Hit Effect
    public event OnCalculatePlayerAttackDamageDelegate  OnCalculatePlayerAttackDamage;  // Calc Add Player Damage
    public event OnCalculatePlayerHitDamageDelegate     OnCalculatePlayerHitDamage;     // Calc Player Hit Damage

    public event Action<CardInfoSO> OnObtainCardEvent;
    public event Action<CardInfoSO> OnRemoveCardEvent;

    public override void Init()
    {

        if (_playerTrm == null)
            _playerTrm = GameObject.Find("Player").transform;

        if (_playerTrm != null)
            _playerStat = _playerTrm.GetComponent<PlayerStat>();

        SetCardData(CardManager.Instance.CardList);
        _playerCurrentCardCount = 0;

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

        if (_playerCardCount[card] == card.CardMaxLevel)
        {

            // 더 이상 해당 카드가 나오지 않도록 처리


        }

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
    public PlayerStat GetPlayerStat()                                       => _playerStat;

    public float CalcPlayerDamage()
    {

        PlayerStatData data = _playerStat.GetPlayerStatData();
        float damage = data.Strength;

        foreach(OnCalculatePlayerAttackDamageDelegate calcPlayerAttackDamageDelegate 
            in OnCalculatePlayerAttackDamage.GetInvocationList())
        {

            if (calcPlayerAttackDamageDelegate == null)
                continue;

            damage += calcPlayerAttackDamageDelegate.Invoke(data);

        }

        return damage;

    }
    public float CalcPlayerHitDamage(float damage)
    {

        PlayerStatData data = _playerStat.GetPlayerStatData();

        foreach (OnCalculatePlayerHitDamageDelegate calcPlayerHitDamageDelegate
            in OnCalculatePlayerHitDamage.GetInvocationList())
        {

            if (calcPlayerHitDamageDelegate == null)
                continue;

            damage += calcPlayerHitDamageDelegate.Invoke(data);

        }

        return damage;

    }

}
