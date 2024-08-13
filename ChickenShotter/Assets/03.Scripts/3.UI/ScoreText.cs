using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{

    private TextMeshProUGUI _scoreText;

    private void Start()
    {

        _scoreText = GetComponent<TextMeshProUGUI>();
        GameManager.Instance.OnUpdateScoreEvent += HandleUpdateScore;

    }

    private void HandleUpdateScore(int score)
    {

        if(_scoreText != null)
        {

            _scoreText.text = $"{score}m";

        }

    }
}
