using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardSkillEffect_AddStatByCurseSO", menuName = "SO/Card/CardEffect/AddStatByCurse")]
public class CardEffect_AddStatByCurseSO : CardEffectSO
{

    public CardAddStatInfo CardAddStatInfoByCurseCount;

    // 저주 카드 개수에 따른 스탯 추가
    // 저주 카드 개수가 달라지면 스탯이 또 추가되야 하는 거겠지
    public override void UseCardEffect(CardInfoSO cardInfoSO)
    {

        PlayerManager playerManager = PlayerManager.Instance;
        PlayerStat playerStat = playerManager.GetPlayerStat();

        if(playerManager.GetCurrentCardCount(cardInfoSO) == 0)          // 저주 카드 개수가 바뀔 때 스탯 변경해주기
        {
            playerManager.OnObtainCardEvent += HandleUpdateAddPlayerStat;
            playerManager.OnRemoveCardEvent += HandleUpdateRemovePlayerStat;
        }

        int cursedCardCount = 0;
        foreach(var cardAndCardCount in playerManager.GetPlayerCardCountDictionary())
        {

            if(cardAndCardCount.Key.CardType == CardType.Cursed)
                cursedCardCount++;

        }

        playerStat.AddPlayerStat(CardAddStatInfoByCurseCount * cursedCardCount);

    }

    public override void RemoveCardEffect(CardInfoSO cardInfoSO)
    {

        PlayerManager playerManager = PlayerManager.Instance;
        PlayerStat playerStat = playerManager.GetPlayerStat();

        if (playerManager.GetCurrentCardCount(cardInfoSO) == 1)          // 마지막 카드라면
        {
            playerManager.OnObtainCardEvent -= HandleUpdateAddPlayerStat;
            playerManager.OnRemoveCardEvent -= HandleUpdateRemovePlayerStat;
        }

        int cursedCardCount = 0;
        foreach (var cardAndCardCount in playerManager.GetPlayerCardCountDictionary())
        {

            if (cardAndCardCount.Key.CardType == CardType.Cursed)
                cursedCardCount++;

        }

        playerStat.RemovePlayerStat(CardAddStatInfoByCurseCount * cursedCardCount);

    }

    private void HandleUpdateAddPlayerStat(CardInfoSO cardInfoSO)
    {

        if (cardInfoSO.CardType != CardType.Cursed)
            return;

        PlayerManager playerManager = PlayerManager.Instance;
        PlayerStat playerStat = playerManager.GetPlayerStat();

        playerStat.AddPlayerStat(CardAddStatInfoByCurseCount);

    }

    private void HandleUpdateRemovePlayerStat(CardInfoSO cardInfoSO)
    {

        if (cardInfoSO.CardType != CardType.Cursed)
            return;

        PlayerManager playerManager = PlayerManager.Instance;
        PlayerStat playerStat = playerManager.GetPlayerStat();

        playerStat.RemovePlayerStat(CardAddStatInfoByCurseCount);

    }

}
