using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    private Image _fillAmount;
    private Image _miniChicken;
    private StageManager _sm;
    // Start is called before the first frame update
    private void Awake()
    {
        _fillAmount = GameObject.Find("Canvas/HpGageMask/ImageFill").GetComponent<Image>();
        _miniChicken = GameObject.Find("Canvas/ClearLine/miniIChicken").GetComponent<Image>();
        _sm = GameObject.Find("StageManager").GetComponent<StageManager>();
    }
    private void Update()
    {
        //체력바
        _fillAmount.fillAmount = 1f - (float)( PlayerManager.Instance.PlayerMaxHealth - PlayerManager.Instance.PlayerCurrentHealth ) / (float)PlayerManager.Instance.PlayerMaxHealth;
        //진행도
        Vector3 pos = _miniChicken.transform.position;
        pos.x = Mathf.Lerp(1000, 1860, _sm.CrtTime / _sm.ClearTime);
        _miniChicken.transform.position = pos;
        //클리어
        if (_sm.CrtTime >= _sm.ClearTime)
        {
            _sm.CurrentStage++;
            PlayerPrefs.SetInt("crtStage", _sm.CurrentStage);
            SceneManager.LoadScene("GetCard");
        }
            

        
    }
}
