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
    private TMP_InputField _timeScaleSetter;

    private bool _isEditMode = false;

    private Dictionary<string, Action<int>> _setValueCommandList;

    private void Awake()
    {

        _timeScaleSetter.onSelect.AddListener(SetTestMode);
        _timeScaleSetter.onEndEdit.AddListener(UnsetTestMode);

        _setValueCommandList = new Dictionary<string, Action<int>>()
        {
            { "set time", SetTime }
        };

    }

    private void SetTestMode(string text)
    {

        TimeManager.Instance.SetTime(0f);
        _isEditMode = true;

    }
    private void UnsetTestMode(string text)
    {

        TimeManager.Instance.SetTime(1f);
        _isEditMode = false;

        UseTestCode(text);

    }

    private void SetTime(int value)
    {

        TimeManager.Instance.SetTime(value);

    }

    private void UseTestCode(string text)
    {
        Debug.Log($"UseTestCode {text}");
        if (string.IsNullOrEmpty(text))
            return;

        foreach(var command in _setValueCommandList)
        {
            Debug.Log($"UseTestCode - command length {command.Key.Length} : text Length {text.Length}");
            if (command.Key.Length > text.Length)
                continue;

            Debug.Log($"UseTestCode - substring Text {command.Key} == {text.Substring(0, command.Key.Length)}, value = {command.Key == text.Substring(0, command.Key.Length)}");
            if (command.Key == text.Substring(0, command.Key.Length))
            {

                if (text.Length <= command.Key.Length + 1)
                    return;

                string value = text.Substring(command.Key.Length + 1);
                command.Value?.Invoke(int.Parse(value));
                Debug.Log($"Invoke {text}");

            }

        }
        



    }
}
