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
        statTxt.text = $"< 플레이어 스탯 >\n돈 : {PlayerManager.Instance.Money} \n최대체력 : {PlayerManager.Instance.PlayerMaxHealth} \n체력 : {PlayerManager.Instance.PlayerCurrentHealth} \n" +
            $"공격력 : {PlayerManager.Instance.PlayerStrength} \n탄알 수 : {PlayerManager.Instance.PlayerBulletNum} \n관통 : {PlayerManager.Instance.Pierce}\n얼음 속성 : {PlayerManager.Instance.Ice} \n" +
            $"불 속성 : {PlayerManager.Instance.Fire} \n전기 속성 : {PlayerManager.Instance.Electric} \n속도 : {PlayerManager.Instance.PlayerSpeed}";
    }

}
