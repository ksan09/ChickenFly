using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectCardPanel : IngamePanel
{

    [SerializeField]
    private TMP_Text _titleText;

    [SerializeField]
    private List<CardUI> _cards = new List<CardUI>();
    private CardUI _selectedCard;

    private Image _panelImage;

    private bool _isSelectCard = false;

    private void Awake()
    {
        
        _panelImage = GetComponent<Image>();

        foreach(var card in _cards)
        {

            card.OnCardEnter += SelectCard;
            card.OnCardClick += ObtainCard;

        }

    }

    public override void OnOpenEvent()
    {

        base.OnOpenEvent();
        _isSelectCard = false;
        _panelImage.color = new Color(0, 0, 0, 0.4f);
        _titleText.color = Color.white;

        List<CardInfoSO> cardData = CardManager.Instance.GetCardList();
        List<CardInfoSO> shuffleCardData = UtillSystem.ShuffleList<CardInfoSO>(cardData, 3);

        for(int i = 0; i < 3; ++i)
        {
            SetCard(i, shuffleCardData[i]);
        }

    }

    public override void OnCloseTransition()
    {

        _panelImage.DOFade(0f, 0.2f)
            .OnComplete(() =>
            {
                gameObject.SetActive(false);
            });

    }



    public void SetCard(int num, CardInfoSO cardSO)
    {

        if (_cards.Count <= num)
            return;

        _cards[num].transform.localScale = Vector3.one;

        RectTransform rectTrm = _cards[num].CardRectTransform;
        Vector3 localPos = rectTrm.anchoredPosition;
        localPos.x = 460f + num * 500f; 
        localPos.y = -540f;
        rectTrm.anchoredPosition = localPos;

        _cards[num].SetColor(Color.white);
        _cards[num].SetCardUI(cardSO);

    }

    private void ObtainCard(CardUI cardUI)
    {

        if (_isSelectCard)
            return;

        _isSelectCard = true;
        PlayerManager.Instance.ObtainCard(cardUI.CardInfoSO);

        // 현재 카드 외에는 전부 안 보이도록 처리
        _titleText.color = Color.clear;

        for (int i = 0; i < _cards.Count; ++i)
        {
            if (cardUI == _cards[i])
                continue;

            _cards[i].transform.localScale = Vector3.zero;

        }

        RectTransform cardTrm = cardUI.CardRectTransform;
        Color startColor = Color.white;
        Color endColor = new Color(1, 1, 1, 0);
        // 눌린 효과
        // 크기가 작아졌다가 
        // 커지면서
        // 
        // 가운데로 이동 후 확대 텍스트 한 번 더 강조하고
        // 페이드하면서 크기 올라가며 사라짐
        Sequence seq = DOTween.Sequence();
        seq.Append(cardTrm.DOScale(Vector3.one * 0.9f, 0.2f).SetEase(Ease.OutBack))
            .Append(cardTrm.DOScale(Vector3.one, 0.1f).SetEase(Ease.OutElastic));

        seq.Append(cardTrm.DOAnchorPos(new Vector2(960f, -540f), 0.2f).SetEase(Ease.OutBack))
            .Join(cardTrm.DOScale(Vector3.one * 1.1f, 0.2f).SetEase(Ease.OutBack))
            .Join(cardTrm.DOScale(Vector3.one, 0.2f).SetEase(Ease.OutElastic));

        seq.Append(cardTrm.DOScale(Vector3.one * 1.5f, 0.2f).SetEase(Ease.OutBounce))
            .AppendInterval(1f);

        seq.Append(cardTrm.DOScale(Vector3.one * 1f, 0.5f).SetEase(Ease.OutCirc));
        seq.Join(cardTrm.DOAnchorPosY(-400f, 0.5f).SetEase(Ease.OutCirc))
            .Join(DOTween.To(() => startColor, color => cardUI.SetColor(color), endColor, 0.5f).SetEase(Ease.Linear).SetDelay(0.1f))
            .OnComplete(() =>
            {

                UIManager.Instance.ClosePanel(PanelType.SelectCard);

            });
        
        

    }

    public void SelectCard(CardUI cardUI)
    {

        if (cardUI == _selectedCard || _isSelectCard)
            return;

        foreach (var card in _cards)
        {

            if(card == cardUI)
            {

                cardUI.SetColor(Color.white);

                Sequence seq = DOTween.Sequence();
                Transform trm = cardUI.transform;
                trm.DOKill();

                trm.localScale = Vector3.one;
                trm.localEulerAngles = Vector3.zero;
                seq.Append(trm.DOScale(Vector3.one * 1.3f, 0.2f).SetEase(Ease.OutBounce))
                    .Join(trm.DORotate(new Vector3(0, 0, -5f), 0.1f).SetEase(Ease.InBack))
                    .Append(trm.DORotate(new Vector3(0, 0, 5f), 0.1f).SetEase(Ease.OutBack))
                    .Append(trm.DORotate(new Vector3(0, 0, 0), 0.1f).SetEase(Ease.OutBounce));

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

        trm.localEulerAngles = Vector3.zero;

        if (_selectedCard != null || cardUI == _selectedCard)
            trm.localScale = Vector3.one * 1.2f;
        else
            trm.localScale = Vector3.one;

        trm.DOScale(Vector3.one * 0.9f, 0.2f).SetEase(Ease.OutBack);

    }

}
