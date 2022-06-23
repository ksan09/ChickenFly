using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class StartUi : UiMove
{
    [SerializeField]
    private RectTransform mainPanel;
    [SerializeField]
    private CrtPanel crtPanel;
    private void Update()
    {
        if(crtPanel.State == PanelState.start)
        {
            BtnMove();
            EnterKey();
        }
    }
    private void EnterKey()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            if (_currentBtnNum == 0)
            {
                PlayerPrefs.SetInt("crtStage", 1);
                SceneManager.LoadScene("Play");
            }
            else if (_currentBtnNum == 1)
            {
                mainPanel.transform.DOMoveY(-2000f, 1f); // 1560
                crtPanel.State = PanelState.shop;
                Debug.Log("�������� �̵�");

            }
            else if (_currentBtnNum == 2)
            {
                mainPanel.transform.DOMoveY(2000f, 1f); // 2540
                crtPanel.State= PanelState.setting;
                Debug.Log("�������� �̵�");
            }
            else if (_currentBtnNum == 3)
            {
                Application.Quit();
            }
        }
    }
}
