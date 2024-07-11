using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCardPanel : IngamePanel
{

    [SerializeField]
    private List<CardUI> _cards = new List<CardUI>();

    public override void OnOpenEvent()
    {

        base.OnOpenEvent();

        List<CardInfoSO> cardData = CardManager.Instance.GetCardList();
        List<CardInfoSO> shuffleCardData = UtillSystem.ShuffleList<CardInfoSO>(cardData, 3);

        for(int i = 0; i < 3; ++i)
        {
            SetCard(i, shuffleCardData[i]);
        }

    }

    public void SetCard(int num, CardInfoSO cardSO)
    {

        if (_cards.Count <= num)
            return;

        _cards[num].SetCardUI(cardSO);

    }

}
