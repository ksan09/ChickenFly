using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnChangedHealthDelegate(float maxHealth, float currentHealth);

public class HealthObject : MonoBehaviour, IHitAble
{

    public event OnChangedHealthDelegate OnChangedHealthEvent;
    public event Action OnHitEvent;
    public event Action OnDieEvent;

    [Header("Health Info")]
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _currentHealth;

    public float MaxHealth => _maxHealth;
    public float CurrentHealth => _currentHealth;

    public void Init(float maxHealth)
    {
        
        _maxHealth      = maxHealth;
        _currentHealth  = maxHealth;

    }

    public void OnHit(float damage)
    {

        if (damage <= 0)    // 데미지가 0이하면 리턴
            return;

        AddHealth(-damage); // 데미지 적용
        OnHitEvent?.Invoke();

        if(_currentHealth <= 0)
        {

            OnDieEvent?.Invoke();

        }

    }

    public void AddMaxHealth(float addValue)
    {

        _maxHealth += addValue;
        OnChangedHealthEvent?.Invoke(_maxHealth, _currentHealth);

        if (addValue > 0)
            AddHealth(addValue);

    }
    public void ChangeMaxHealth(float value)
    {

        if (value == _maxHealth)
            return;

        value -= _maxHealth;
        AddMaxHealth(value);

    }
    public void AddHealth(float addValue)
    {

        _currentHealth = Mathf.Clamp(_currentHealth + addValue, 0, _maxHealth);
        OnChangedHealthEvent?.Invoke(_maxHealth, _currentHealth);

    }

}
