using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class ShopUi : UiMove
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
            crtPanel.State = PanelState.start;
        }
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            
            if (_currentBtnNum == 1)
            {
                Debug.Log("샷건 선택");

            }
            else if (_currentBtnNum == 2)
            {
                
                Debug.Log("레이저 구매나 선택");
            }
            else if (_currentBtnNum == 3)
            {
                Debug.Log("유도탄 구매나 선택");
            }
        }
    }
}
