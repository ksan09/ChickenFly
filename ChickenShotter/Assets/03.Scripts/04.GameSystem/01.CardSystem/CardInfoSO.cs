using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "A_CardInfoSO", menuName = "SO/Card/CardInfoSO")]
public class CardInfoSO : ScriptableObject
{

    [Header("Card Info")]
    public string   CardName;
    public int      CardMaxLevel;
    public CardType CardType;
    public Sprite   CardImage;
    public string   CardExplain;

    [Header("Card Effect")]
    public bool NoCounting = false;
    public CardAbilityData CardEffect;

}
