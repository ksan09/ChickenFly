using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RandomStage : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _choice1Txt;
    [SerializeField]
    private TextMeshProUGUI _choice2Txt;
    private int stageState;// 스테이지 랜덤 변수
    private int stageState2; // 스테이지 랜덤 변수2
    private bool rdCheck = true; // 랜덤 확률 겹치지 않도록
    void Start()
    {
        Stage();

    }
    public int StageState { get { return stageState; } }
    public int StageState2 { get { return stageState2; } }
    private void Stage()
    {
        stageState = Random.Range(1, 5); // 1~4
        switch (stageState)
        {
            case 1:
                _choice1Txt.text = "Shop";
                break;
            case 2:
                _choice1Txt.text = "Event";
                break;
            case 3:
                _choice1Txt.text = "Gamble";
                break;
            case 4:
                _choice1Txt.text = "Altar";
                break;
            default:
                break;
        }
        stageState2 = Random.Range(1, 5); // 1~4
        while (rdCheck)
        {
            if (stageState2 != stageState)
            {
                rdCheck = false;
            }
            else
            {
                stageState2 = Random.Range(1, 5);
            }
        }
        switch (stageState2)
        {
            case 1:
                _choice2Txt.text = "Shop";
                break;
            case 2:
                _choice2Txt.text = "Event";
                break;
            case 3:
                _choice2Txt.text = "Gamble";
                break;
            case 4:
                _choice2Txt.text = "Altar";
                break;
            default:
                break;
        }
        rdCheck = true;
    }
}
