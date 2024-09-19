using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardSkillEffect_RemoveCardTypeSO", menuName = "SO/Card/CardEffect/RemoveCardType")]
public class CardEffect_BlessingSO : CardEffectSO
{

    public CardType TargetType;

    // ���� Ư�� Ÿ�� ī�带 �ٲ� Ÿ�� ī��� ����
    public override void UseCardEffect(CardInfoSO cardInfoSO)
    {

        List<CardInfoSO> cards = new List<CardInfoSO>();
        var playerCards = PlayerManager.Instance.GetPlayerCardCountDictionary();

        foreach(var cardCountData in playerCards)
        {

            CardInfoSO card = cardCountData.Key;
            if (card.CardType != TargetType)
                continue;

            for(int i = 0; i < cardCountData.Value; ++i)
            {
                cards.Add(card);
            }

        }

        foreach (var card in cards)
            PlayerManager.Instance.RemoveCard(card);


    }

    public override void RemoveCardEffect(CardInfoSO cardInfoSO)
    {

    }

}
