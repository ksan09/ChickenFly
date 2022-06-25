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
        statTxt.text = $"< �÷��̾� ���� >\n�� : {PlayerManager.Instance.Money} \n�ִ�ü�� : {PlayerManager.Instance.PlayerMaxHealth} \nü�� : {PlayerManager.Instance.PlayerCurrentHealth} \n" +
            $"���ݷ� : {PlayerManager.Instance.PlayerStrength} \nź�� �� : {PlayerManager.Instance.PlayerBulletNum} \n���� : {PlayerManager.Instance.Pierce}\n���� �Ӽ� : {PlayerManager.Instance.Ice} \n" +
            $"�� �Ӽ� : {PlayerManager.Instance.Fire} \n���� �Ӽ� : {PlayerManager.Instance.Electric} \n�ӵ� : {PlayerManager.Instance.PlayerSpeed}";
    }

}
