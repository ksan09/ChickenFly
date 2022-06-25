using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SkillUi : UiMove
{
    [SerializeField]
    private RectTransform mainPanel;
    [SerializeField]
    private CrtPanel crtPanel;
    [SerializeField]
    StartSoundSettingTest sSST;
    // Update is called once per frame
    void Update()
    {
        if (crtPanel.State == PanelState.skill)
        {
            EnterKey();
            BtnMove();
        }
        

    }
    private void EnterKey()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            mainPanel.transform.DOMoveY(2000, 1f); // 0
            crtPanel.PanelChanging(PanelState.setting);
        }
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            if (_currentBtnNum == 1)
            {
                PlayerManager.Instance.State = PlayerSkillState.Shotgun;
                sSST.SettingSkill();
            }
            if (_currentBtnNum == 2)
            {
                PlayerManager.Instance.State = PlayerSkillState.Laser;
                sSST.SettingSkill();
            }
            if( _currentBtnNum == 3)
            {
                PlayerManager.Instance.State = PlayerSkillState.guidedMissile;
                sSST.SettingSkill();
            }
        }
    }
}
