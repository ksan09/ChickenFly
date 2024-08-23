using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnUpdatePlayerExpBarDelegate(float currentExp, float needExp);

public class PlayerLevel : MonoBehaviour
{

    public event OnUpdatePlayerExpBarDelegate OnUpdateExpBarEvent;

    [Header("Level Data")]
    [SerializeField] private PlayerLevelData _playerLevelData;

    private int _currentLevel = 0;
    private float _currentExp = 0;
    private float _needExp;

    private void Awake()
    {
        
        _needExp = _playerLevelData._needExpByLevelList[0];

    }

    public void AddExp(float value)
    {

        if (_currentLevel >= _playerLevelData._needExpByLevelList.Count)
            return;

        _currentExp += value;

        if(_currentExp >= _needExp)
        {

            // Level Up
            UIManager.Instance.OpenPanel(PanelType.SelectCard);
            _currentExp = _currentExp - _needExp;

            _currentLevel++;
            if (_currentLevel >= _playerLevelData._needExpByLevelList.Count)
                return;

            _needExp = _playerLevelData._needExpByLevelList[_currentLevel];

        }

        OnUpdateExpBarEvent?.Invoke(_currentExp, _needExp);

    }


}
