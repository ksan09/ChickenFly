using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class GameTester : MonoBehaviour
{

    [SerializeField]
    private TMP_InputField _inputCommandField;

    [SerializeField]
    private GameObject _statPanel;

    private bool _isEditMode = false;
    private float _lastTimeScale = 1f;

    private Dictionary<string, Action<int>> _setValueCommandList;
    private Dictionary<string, Action> _invokeCommandList;

    private void Awake()
    {

        _inputCommandField.onSelect.AddListener(SetTestMode);
        _inputCommandField.onEndEdit.AddListener(UnsetTestMode);

        _setValueCommandList = new Dictionary<string, Action<int>>()
        {
            { "set time", SetTime },
            { "set card", SetCard },
            { "add score", GameManager.Instance.AddScore }
        };

        _invokeCommandList = new Dictionary<string, Action>
        {
            { "open panel card", OpenCardPanel },
            { "close panel card", CloseCardPanel }
        };

    }

    private void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.P))
        {
            _statPanel.SetActive(!_statPanel.activeInHierarchy);
            PlayerManager.Instance.UpdatePlayerStatUI();
        }

    }

    private void SetTestMode(string text)
    {

        _lastTimeScale = Time.timeScale;
        TimeManager.Instance.SetTime(0f);
        _isEditMode = true;

    }
    private void UnsetTestMode(string text)
    {

        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);

        TimeManager.Instance.SetTime(_lastTimeScale);
        _isEditMode = false;

        UseTestCode(text);

    }

    private void SetTime(int value)
    {

        TimeManager.Instance.SetTime(value);

    }
    private void SetCard(int value)
    {

        SelectCardPanel selectCardPanel = UIManager.Instance.GetPanel(PanelType.SelectCard) as SelectCardPanel;

        if (selectCardPanel != null)
        {

            CardInfoSO cardInfo = CardManager.Instance.GetCard(value);

            if (cardInfo == null)
                return;

            selectCardPanel.SetCard(1, cardInfo);

        }

    }
    private void OpenCardPanel()
    {

        UIManager.Instance.OpenPanel(PanelType.SelectCard);

    }
    private void CloseCardPanel()
    {

        UIManager.Instance.ClosePanel(PanelType.SelectCard);

    }

    private void UseTestCode(string text)
    {
        Debug.Log($"UseTestCode {text}");
        if (string.IsNullOrEmpty(text))
            return;

        // value Command
        foreach(var command in _setValueCommandList)
        {

            if (command.Key.Length > text.Length)
                continue;

            if (command.Key == text.Substring(0, command.Key.Length))
            {

                if (text.Length <= command.Key.Length + 1)
                    return;

                string value = text.Substring(command.Key.Length + 1);
                command.Value?.Invoke(int.Parse(value));
                Debug.Log($"Invoke {text}");
                return;

            }

        }

        // invoke Command
        foreach (var command in _invokeCommandList)
        {

            if (command.Key.Length > text.Length)
                continue;

            if (command.Key == text.Substring(0, command.Key.Length))
            {

                command.Value?.Invoke();
                Debug.Log($"Invoke {text}");
                return;

            }

        }


    }
}
