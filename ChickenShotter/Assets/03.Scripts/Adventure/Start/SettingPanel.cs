using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class SettingPanel : UiMove
{
    [SerializeField]
    private RectTransform mainPanel;
    [SerializeField]
    private CrtPanel crtPanel;
    private void Update()
    {
        if (crtPanel.State == PanelState.setting)
        {
            BtnMove();
            EnterKey();
        }
    }
    private void EnterKey()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            mainPanel.transform.DOMoveY(540, 1f); // 0
            crtPanel.PanelChanging(PanelState.start);
        }
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {

            if (_currentBtnNum == 1)
            {
                mainPanel.transform.DOMoveY(4000f, 1f); // 2540
                crtPanel.PanelChanging(PanelState.sounds);
                Debug.Log("사운드 설정으로 이동");

            }
            if (_currentBtnNum == 2)
            {
                mainPanel.transform.DOMoveY(6000f, 1f); // 5460
                crtPanel.PanelChanging(PanelState.skill);
                Debug.Log("스킬 설정으로 이동");

            }
        }
    }
}
