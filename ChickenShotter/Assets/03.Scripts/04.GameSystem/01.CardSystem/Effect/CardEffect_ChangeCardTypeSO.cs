using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardSkillEffect_ChangeCardTypeSO", menuName = "SO/Card/CardEffect/ChangeCardType")]
public class CardEffect_ChangeCardTypeSO : CardEffectSO
{

    public CardType TargetType;
    public CardType ChangeType;

    // 덱에 특정 타입 카드를 바꿀 타입 카드로 변경
    public override void UseCardEffect(CardInfoSO cardInfoSO)
    {



    }

    public override void RemoveCardEffect(CardInfoSO cardInfoSO)
    {

    }

}
