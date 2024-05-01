using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    private Image _cardImage;
    private TextMeshProUGUI _cardTxt;
    private TextMeshProUGUI _cardExplainTxt;
    private CardStatSO _cardStatSO;

    public void SetCard(CardStatSO cardStatSO)
    {

        _cardStatSO = cardStatSO;


    }


}
