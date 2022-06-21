using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageChoice : MonoBehaviour
{
    private RandomStage rs;
    //1상점2이벤트3도박4신전
    private void Awake()
    {
        rs = GetComponent<RandomStage>();
    }

    // Update is called once per frame
    public void clickStage()
    {
        switch(rs.StageState)
        {
            case 1:
                SceneManager.LoadScene("Shop");
                break;
            case 2:
                SceneManager.LoadScene("Event");
                break;
            case 3:
                SceneManager.LoadScene("Gamble");
                break;
            case 4:
                SceneManager.LoadScene("Altar");
                break;
            default:
                break;
        }
    }
    public void clickStage2()
    {
        switch (rs.StageState2)
        {
            case 1:
                SceneManager.LoadScene("Shop");
                break;
            case 2:
                SceneManager.LoadScene("Event");
                break;
            case 3:
                SceneManager.LoadScene("Gamble");
                break;
            case 4:
                SceneManager.LoadScene("Altar");
                break;
            default:
                break;
        }
    }
}
