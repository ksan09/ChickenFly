using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetCardPanel : IngamePanel
{

    [SerializeField]
    private CardUI _cardUI;
    private Button _nextBtn;

    private List<CardInfoSO> _cards;
    private int _currentCardIndex;

    private void Awake()
    {
        
        _nextBtn = transform.Find("Button").GetComponent<Button>();
        _nextBtn.onClick.AddListener(HandleNextCard);

    }

    public void SetCardList(List<CardInfoSO> cards)
    {

        _cards = cards;
        _currentCardIndex = 0;

        PlayerManager.Instance.ObtainCard(_cards[_currentCardIndex]);
        _cardUI.SetCardUI(_cards[_currentCardIndex++]);
        BouncingTween();

    }

    private void HandleNextCard()
    {

        if (_currentCardIndex >= _cards.Count)
        {

            UIManager.Instance.ClosePanel(PanelType.GetCard);
            return;

        }

        Debug.Log(_cards[_currentCardIndex]);
        PlayerManager.Instance.ObtainCard(_cards[_currentCardIndex]);
        _cardUI.SetCardUI(_cards[_currentCardIndex++]);
        BouncingTween();

    }

    Sequence seq;
    private void BouncingTween()
    {

        RectTransform rectTrm = _cardUI.CardRectTransform;
        rectTrm.DOKill();
        rectTrm.localScale = Vector3.one * 1.2f;

        if (seq != null)
            seq.Kill();

        seq = DOTween.Sequence();
        seq.SetUpdate(true);

        seq.Append(rectTrm.DOScale(1.4f, 1f).SetEase(Ease.OutElastic));

    }


}
