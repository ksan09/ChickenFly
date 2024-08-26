using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPBar : MonoBehaviour
{

    [Header("Info")]
    [SerializeField] private Image _feelImage;
    [SerializeField] private TextMeshProUGUI _hpText;

    private void Start()
    {

        HealthObject playerHealth = PlayerManager.Instance.GetPlayerHealth();
        playerHealth.OnChangedHealthEvent += HandleUpdateUIWhenChangedHealth;
        HandleUpdateUIWhenChangedHealth(playerHealth.MaxHealth, playerHealth.MaxHealth);

    }

    private void HandleUpdateUIWhenChangedHealth(float maxHealth, float currentHealth)
    {

        if(_hpText == null || _feelImage == null)
        {

            Debug.LogError("Null HpText or FeelImage");
            return;

        }

        _hpText.text = $"{Mathf.Ceil(currentHealth)} / {Mathf.Ceil(maxHealth)}";
        _feelImage.fillAmount = currentHealth / maxHealth;

    }
}
