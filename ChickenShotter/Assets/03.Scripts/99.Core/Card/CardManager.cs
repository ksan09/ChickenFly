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
    private Dictionary<CardType, List<CardInfoSO>> _cardListByType; // 
    private Dictionary<CardType, List<CardInfoSO>> _noObtainEffectCardListByType; // 카드 획득용

    public List<CardInfoSO> CardList { get { return _cards.ToList(); } }

    public override void Init()
    {

        _cards = _cardListSO.CardList.ToList<CardInfoSO>();
        _cardListByType = new Dictionary<CardType, List<CardInfoSO>>()
        {
            { CardType.Normal,  new List<CardInfoSO>() },
            { CardType.Rare,    new List<CardInfoSO>() },
            { CardType.Cursed,  new List<CardInfoSO>() },
        };
        
        _noObtainEffectCardListByType = new Dictionary<CardType, List<CardInfoSO>>()
        {
            { CardType.Normal,  new List<CardInfoSO>() },
            { CardType.Rare,    new List<CardInfoSO>() },
            { CardType.Cursed,  new List<CardInfoSO>() },
        };

        // Info Setting
        foreach(CardInfoSO card in _cards)
        {

            _cardListByType[card.CardType].Add(card);

            List<CardEffectSO> effects = card.CardEffect.CardEffectList;
            if (effects != null && effects.Count > 0)
            {

                bool effectCheck = false;
                for(int i = 0; i < effects.Count; ++i)
                {

                    if (effects[i] is CardEffect_GetCardSO
                        || effects[i] is CardEffect_ShuffleSO
                        || effects[i] is CardEffect_BlessingSO)
                    {

                        effectCheck = true;
                        break;

                    }

                }

                if (effectCheck)
                    continue;

            }

            _noObtainEffectCardListByType[card.CardType].Add(card);

        }

    }

    public List<CardInfoSO> GetCardList() => _cards.ToList();
    public List<CardInfoSO> GetCardList(CardType type) => _cardListByType[type].ToList();
    public List<CardInfoSO> GetNoObtainEffectCardList(CardType type) => _noObtainEffectCardListByType[type].ToList();
    public CardInfoSO GetCard(int num)
    {

        if(_cards.Count <= num)
        {
            return null;
        }

        return _cards[num];

    }

    public List<CardInfoSO> GetRandomCardByPlayerLuck(int count, bool noDuplication = true, bool isGetCard = false)
    {
        // Return List
        List<CardInfoSO> cards = new List<CardInfoSO>();

        // Player Stat
        PlayerStatData data = PlayerManager.Instance.GetPlayerStat().GetPlayerStatData();
        float luck = data.Luck;
        float curseLuck = data.CurseLuck;

        // Card Probability
        // NormalProb = 1.0f - (rareProb+curseProb)
        float rareProb = 0.22f + 0.01f * luck;          // 22%
        float curseProb = 0.18f + 0.01f * curseLuck;    // 18%

        // Calc Card Probability
        List<CardInfoSO> normalCards = isGetCard ? GetNoObtainEffectCardList(CardType.Normal) : GetCardList(CardType.Normal);
        List<CardInfoSO> rareCards = isGetCard ? GetNoObtainEffectCardList(CardType.Rare) : GetCardList(CardType.Rare);
        List<CardInfoSO> cursedCards = isGetCard ? GetNoObtainEffectCardList(CardType.Cursed) : GetCardList(CardType.Cursed);
        
        for (int i = 0; i < count; ++i)
        {

            //Draw Card
            float randomValue = Random.Range(0f, 1f);
            int randomIndex = 0;
            CardInfoSO card = null;

            if(rareCards.Count > 0 && randomValue <= rareProb)
            {

                randomIndex = Random.Range(0, rareCards.Count);
                card = rareCards[randomIndex];

                if (noDuplication)
                    rareCards.RemoveAt(randomIndex);


            }
            else if(cursedCards.Count > 0 && randomValue <= rareProb + curseProb)
            {

                randomIndex = Random.Range(0, cursedCards.Count);
                card = cursedCards[randomIndex];

                if (noDuplication)
                    cursedCards.RemoveAt(randomIndex);

            }
            else if(normalCards.Count > 0)
            {

                randomIndex = Random.Range(0, normalCards.Count);
                card = normalCards[randomIndex];

                if (noDuplication)
                    normalCards.RemoveAt(randomIndex);

            }
            else
            {

                return cards;

            }

            cards.Add(card);

        }


        return cards;

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

    public void ChangeCardType(CardType targetType, CardType changeType)
    {



    }

    public void ChangeAllCard()
    {

        // 플레이어 카드 리스트를

    }

    public void ResetCardList()
    {
        _cards = _cardListSO.CardList.ToList();
    }

}
