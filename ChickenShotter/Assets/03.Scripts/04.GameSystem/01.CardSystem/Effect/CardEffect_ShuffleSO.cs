using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

[CreateAssetMenu(fileName = "CardSkillEffect_ShuffleSO", menuName = "SO/Card/CardEffect/Shuffle")]
public class CardEffect_ShuffleSO : CardEffectSO
{

    // ���� �� �������� �ڹٲ�
    public override void UseCardEffect(CardInfoSO cardInfoSO)
    {

        int cardCount = 0;
        // ��� ī�带 ����
        var playerCardCountData = PlayerManager.Instance.GetPlayerCardCountDictionary();
        foreach (var playerCardCount in playerCardCountData)
        {

            cardCount += playerCardCount.Value;

        }
        PlayerManager.Instance.RemoveAllCard();

        // ������ �ִ� ī�� ������ŭ ī�带 �������� �߰�
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
