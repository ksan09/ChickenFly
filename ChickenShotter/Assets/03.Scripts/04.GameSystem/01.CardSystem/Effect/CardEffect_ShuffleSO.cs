using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

[CreateAssetMenu(fileName = "CardSkillEffect_ShuffleSO", menuName = "SO/Card/CardEffect/Shuffle")]
public class CardEffect_ShuffleSO : CardEffectSO
{

    // 덱을 다 랜덤으로 뒤바꿈
    public override void UseCardEffect(CardInfoSO cardInfoSO)
    {

        int cardCount = 0;
        // 모든 카드를 삭제
        var playerCardCountData = PlayerManager.Instance.GetPlayerCardCountDictionary();
        foreach (var playerCardCount in playerCardCountData)
        {

            cardCount += playerCardCount.Value;

        }
        PlayerManager.Instance.RemoveAllCard();

        // 이전에 있던 카드 개수만큼 카드를 랜덤으로 추가
        List<CardInfoSO> cards = CardManager.Instance.GetRandomCardByPlayerLuck(cardCount, false, true);

        GetCardPanel getPanel = UIManager.Instance.GetPanel(PanelType.GetCard) as GetCardPanel;
        if (getPanel != null)
        {
            getPanel.SetCardList(cards);
            UIManager.Instance.OpenPanel(PanelType.GetCard);
        }

    }

    public override void RemoveCardEffect(CardInfoSO cardInfoSO)
    {

    }

}
