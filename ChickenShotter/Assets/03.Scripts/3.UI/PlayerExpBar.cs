using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerExpBar : MonoBehaviour
{

    [Header("Info")]
    [SerializeField] private Image _feelImage;

    private void Start()
    {

        PlayerLevel playerLevel = PlayerManager.Instance.GetPlayerLevel();
        playerLevel.OnUpdateExpBarEvent += HandleUpdateUIWhenChangedExp;

    }

    private void HandleUpdateUIWhenChangedExp(float currentExp, float maxExp)
    {

        if (_feelImage == null)
        {

            Debug.LogError("Null HpText or FeelImage");
            return;

        }

        _feelImage.fillAmount = currentExp / maxExp;

    }

}
