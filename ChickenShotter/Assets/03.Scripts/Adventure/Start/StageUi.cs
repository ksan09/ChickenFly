using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class StageUi : UiMove
{
    [SerializeField]
    private RectTransform mainPanel;
    [SerializeField]
    private CrtPanel crtPanel;
    // Update is called once per frame
    void Update()
    {
        if (crtPanel.State == PanelState.shop)
        {
            EnterKey();
            BtnMove();
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
                PlayerPrefs.SetInt("crtStage", 5);
                PlayerManager.Instance.ResetPlayer();
                PlayerManager.Instance.PlayerBulletNum += 1;
                PlayerManager.Instance.PlayerStrength += 8;
                SceneManager.LoadScene("Play");

            }
            else if (_currentBtnNum == 2)
            {
                PlayerPrefs.SetInt("crtStage", 7);
                PlayerManager.Instance.ResetPlayer();
                PlayerManager.Instance.PlayerBulletNum += 1;
                PlayerManager.Instance.PlayerStrength += 11;
                SceneManager.LoadScene("Play");
            }
            else if (_currentBtnNum == 3)
            {
                PlayerPrefs.SetInt("crtStage", 10);
                PlayerManager.Instance.ResetPlayer();
                PlayerManager.Instance.PlayerBulletNum += 3;
                PlayerManager.Instance.PlayerStrength += 11;
                SceneManager.LoadScene("Play");
            }
            else if (_currentBtnNum == 4)
            {
                PlayerPrefs.SetInt("crtStage", 15);
                PlayerManager.Instance.ResetPlayer();
                PlayerManager.Instance.PlayerBulletNum += 4;
                PlayerManager.Instance.PlayerStrength += 16;
                SceneManager.LoadScene("Play");
            }
            else if (_currentBtnNum == 5)
            {
                PlayerPrefs.SetInt("crtStage", 16);
                PlayerManager.Instance.ResetPlayer();
                PlayerManager.Instance.PlayerBulletNum += 5;
                PlayerManager.Instance.PlayerStrength += 14;
                SceneManager.LoadScene("Play");
            }
        }
    }
}
