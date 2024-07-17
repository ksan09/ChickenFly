using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCardPanel : IngamePanel
{

    [SerializeField]
    private List<CardUI> _cards = new List<CardUI>();
    private CardUI _selectedCard;

    private void Awake()
    {
        
        foreach(var card in _cards)
        {

            card.OnCardEnter += SelectCard;
            card.OnCardClick += ObtainCard;

        }

    }

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

    private void ObtainCard(CardUI cardUI)
    {



    }

    public void SelectCard(CardUI cardUI)
    {

        if (cardUI == _selectedCard)
            return;

        foreach (var card in _cards)
        {

            if(card == cardUI)
            {

                cardUI.SetColor(Color.white);

                Transform trm = cardUI.transform;
                trm.DOKill();

                trm.localScale = Vector3.one;
                trm.DOScale(Vector3.one * 1.3f, 0.2f).SetEase(Ease.OutBounce);

            }
            else
            {

                UnselectCard(card);

            }

        }

        _selectedCard = cardUI;

    }

    private void UnselectCard(CardUI cardUI)
    {

        cardUI.SetColor(Color.gray);

        Transform trm = cardUI.transform;
        trm.DOKill();

        if (_selectedCard != null || cardUI == _selectedCard)
            trm.localScale = Vector3.one * 1.2f;
        else
            trm.localScale = Vector3.one;

        trm.DOScale(Vector3.one * 0.9f, 0.2f).SetEase(Ease.OutBack);

    }

}
