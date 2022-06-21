using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatTxt : MonoBehaviour
{
    private TextMeshProUGUI statTxt;
    private void Awake()
    {
        statTxt = GetComponent<TextMeshProUGUI>();
        statTxt.text = $"Money : {PlayerManager.Instance.Money} \nMaxHp: {PlayerManager.Instance.PlayerMaxHealth} \nHp: {PlayerManager.Instance.PlayerCurrentHealth} \n" +
            $"Strength: {PlayerManager.Instance.PlayerStrength} \nEgg: : {PlayerManager.Instance.PlayerBulletNum} \nIce: {PlayerManager.Instance.Ice} \n" +
            $"Fire: {PlayerManager.Instance.Fire} \nElectric: {PlayerManager.Instance.Electric}";
    }

}
