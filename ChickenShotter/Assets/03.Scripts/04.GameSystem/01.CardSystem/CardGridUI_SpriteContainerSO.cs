using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardGridUI_SpriteContainerSO", menuName = "SO/Card/CardGridUI_SpriteContainerSO")]
public class CardGridUI_SpriteContainerSO : ScriptableObject
{

    [Header("Default")]
    public Sprite   DefaultCardGrid;
    public Sprite   DefaultCardImageGrid;
    public Material DefaultCardGridMaterial;

    [Header("Rare")]
    public Sprite   RareCardGrid;
    public Sprite   RareCardImageGrid;
    public Material RareCardGridMaterial;

    [Header("Cursed")]
    public Sprite   CursedCardGrid;
    public Sprite   CursedCardImageGrid;
    public Material CursedCardGridMaterial;

}
