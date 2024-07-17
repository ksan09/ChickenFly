using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardEffectSO : ScriptableObject
{

    public abstract void UseCardEffect(CardInfoSO cardInfoSO);
    public abstract void RemoveCardEffect(CardInfoSO cardInfoSO);

}
