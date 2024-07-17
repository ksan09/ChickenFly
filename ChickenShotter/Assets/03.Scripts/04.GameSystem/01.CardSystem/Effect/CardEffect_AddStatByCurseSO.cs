using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardSkillEffect_AddStatByCurseSO", menuName = "SO/Card/CardEffect/AddStatByCurse")]
public class CardEffect_AddStatByCurseSO : CardEffectSO
{

    public CardAddStatInfo CardAddStatInfoByCurseCount;

    // ���� ī�� ������ ���� ���� �߰�
    // ���� ī�� ������ �޶����� ������ �� �߰��Ǿ� �ϴ� �Ű���
    public override void UseCardEffect(CardInfoSO cardInfoSO)
    {

        PlayerManager playerManager = PlayerManager.Instance;
        PlayerStat playerStat = playerManager.GetPlayerStat();

        if(playerManager.GetCurrentCardCount(cardInfoSO) == 0)          // ���� ī�� ������ �ٲ� �� ���� �������ֱ�
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

        if (playerManager.GetCurrentCardCount(cardInfoSO) == 1)          // ������ ī����
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
