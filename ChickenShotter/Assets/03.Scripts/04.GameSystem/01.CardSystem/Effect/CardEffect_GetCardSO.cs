using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardSkillEffect_GetCardSO", menuName = "SO/Card/CardEffect/GetCard")]
public class CardEffect_GetCardSO : CardEffectSO
{

    public List<CardType> GetCardList;

    public override void UseCardEffect(CardInfoSO cardInfoSO)
    {

        List<CardInfoSO> getCardList = new List<CardInfoSO>();

        for(int i = 0; i < GetCardList.Count; i++)
        {

            List<CardInfoSO> cards = CardManager.Instance.GetNoObtainEffectCardList(GetCardList[i]);
            CardInfoSO card = cards[Random.Range(0, cards.Count)];

            getCardList.Add(card);

        }

        GetCardPanel panel = UIManager.Instance.GetPanel(PanelType.GetCard) as GetCardPanel;
        if (panel != null)
        {

            panel.SetCardList(getCardList);
            UIManager.Instance.OpenPanel(PanelType.GetCard);

        }

    }

    public override void RemoveCardEffect(CardInfoSO cardInfoSO)
    {

    }

}
