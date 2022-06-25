using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SoundExit : UiMove
{
    [SerializeField]
    private RectTransform mainPanel;
    [SerializeField]
    private CrtPanel crtPanel;
    [SerializeField]
    private Slider bgm;
    [SerializeField]
    private Slider effect;
    [SerializeField]
    StartSoundSettingTest sSST;
    // Update is called once per frame
    void Update()
    {
        if (crtPanel.State == PanelState.sounds)
        {
            EnterKey();
            BtnMove();
        }

    }
    private void Awake()
    {
        bgm.value = PlayerPrefs.GetFloat("bgm", 0);
        effect.value = PlayerPrefs.GetFloat("effect", 0);
    }
    private void EnterKey()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            mainPanel.transform.DOMoveY(2000, 1f); // 0
            bgm.value = PlayerPrefs.GetFloat("bgm", 0);
            effect.value = PlayerPrefs.GetFloat("effect", 0);
            crtPanel.State = PanelState.setting;
        }
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {

            if (_currentBtnNum == 1)
            {
                PlayerPrefs.SetFloat("bgm", bgm.value);
                PlayerPrefs.SetFloat("effect", effect.value);
                sSST.BgmStart();
                Debug.Log("음량 세팅");

            }
        }
    }
}
