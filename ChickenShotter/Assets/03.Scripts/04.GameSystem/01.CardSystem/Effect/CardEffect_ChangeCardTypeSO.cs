using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardSkillEffect_ChangeCardTypeSO", menuName = "SO/Card/CardEffect/ChangeCardType")]
public class CardEffect_ChangeCardTypeSO : CardEffectSO
{

    public CardType TargetType;
    public CardType ChangeType;

    // ���� Ư�� Ÿ�� ī�带 �ٲ� Ÿ�� ī��� ����
    public override void UseCardEffect(CardInfoSO cardInfoSO)
    {



    }

    public override void RemoveCardEffect(CardInfoSO cardInfoSO)
    {

    }

}
