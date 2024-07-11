using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardManager : MonoSingleton<CardManager>
{

    [SerializeField]
    private CardListSO _cardListSO;
    [SerializeField]
    private CardGridUI_SpriteContainerSO _cardGridUI_SpriteContainerSO;

    private List<CardInfoSO> _cards;

    public override void Init()
    {

        _cards = _cardListSO.CardList.ToList<CardInfoSO>();

    }

    public List<CardInfoSO> GetCardList()
    {
        return _cards.ToList();
    }
    public CardInfoSO GetCard(int num)
    {

        if(_cards.Count <= num)
        {
            return null;
        }

        return _cards[num];

    }

    public Sprite GetCardGrid(CardType type)
    {

        if (_cardGridUI_SpriteContainerSO == null)
            return null;

        switch (type)
        {
            case CardType.Normal:
                return _cardGridUI_SpriteContainerSO.DefaultCardGrid;
            case CardType.Rare:
                return _cardGridUI_SpriteContainerSO.RareCardGrid;
            case CardType.Cursed:
                return _cardGridUI_SpriteContainerSO.CursedCardGrid;
        }

        return null;

    }
    public Sprite GetCardImageGrid(CardType type)
    {

        if (_cardGridUI_SpriteContainerSO == null)
            return null;

        switch (type)
        {
            case CardType.Normal:
                return _cardGridUI_SpriteContainerSO.DefaultCardImageGrid;
            case CardType.Rare:
                return _cardGridUI_SpriteContainerSO.RareCardImageGrid;
            case CardType.Cursed:
                return _cardGridUI_SpriteContainerSO.CursedCardImageGrid;
        }

        return null;

    }
    public Material GetCardGridMaterial(CardType type)
    {

        if (_cardGridUI_SpriteContainerSO == null)
            return null;

        switch (type)
        {
            case CardType.Normal:
                return _cardGridUI_SpriteContainerSO.DefaultCardGridMaterial;
            case CardType.Rare:
                return _cardGridUI_SpriteContainerSO.RareCardGridMaterial;
            case CardType.Cursed:
                return _cardGridUI_SpriteContainerSO.CursedCardGridMaterial;
        }

        return null;

    }

}
