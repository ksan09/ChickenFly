using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{

    [Header("CardInfo")]
    [SerializeField] private CardInfoSO _cardInfoSO;
    public CardInfoSO CardInfoSO => _cardInfoSO;

    private Image _cardGrid;
    private Image _cardImageGrid;

    private TextMeshProUGUI     _cardNameText;
    private Image               _cardImage;
    private TextMeshProUGUI     _cardExplainText;

    private void Awake()
    {
        InitCard();
    }

    private void InitCard()
    {
        
        _cardGrid = GetComponent<Image>();
        _cardImageGrid = transform.Find("CardImage").GetComponent<Image>();

        _cardNameText = transform.Find("CardName").GetComponent<TextMeshProUGUI>();
        _cardImage = transform.Find("CardImage/Image").GetComponent<Image>();
        _cardExplainText = transform.Find("CardExplain").GetComponent<TextMeshProUGUI>();

    }

    public void SetCardUI(CardInfoSO cardInfoSO)
    {

        _cardInfoSO             = cardInfoSO;

        _cardGrid.sprite        = CardManager.Instance.GetCardGrid(cardInfoSO.CardType);
        _cardGrid.material      = CardManager.Instance.GetCardGridMaterial(cardInfoSO.CardType);
        _cardImageGrid.sprite   = CardManager.Instance.GetCardImageGrid(cardInfoSO.CardType);

        _cardNameText.text      = cardInfoSO.CardName;
        _cardImage.sprite       = cardInfoSO.CardImage;
        _cardExplainText.text   = cardInfoSO.CardExplain;


    }

    private void OnValidate()
    {

        if (_cardInfoSO == null || CardManager.Instance == null)
            return;

        InitCard();
        SetCardUI(_cardInfoSO);

    }

}
