using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BossStage : MonoBehaviour
{
    [SerializeField] private GameObject boss;
    [SerializeField] private GameObject panel;
    private Image pImg;
    [SerializeField] private GameObject background;
    private Rigidbody2D playerRb;
    // Start is called before the first frame update
    void Start()
    {
        pImg = panel.GetComponent<Image>();
        playerRb = GameObject.Find("PlayerControl/PlayerSprite").GetComponent<Rigidbody2D>();
        playerRb.gravityScale = 0;
        StartCoroutine(StartBossStage());
    }
    IEnumerator StartBossStage()
    {
        yield return new WaitForSeconds(1f);
        background.transform.DOMoveY(555f, 0.5f);
        yield return new WaitForSeconds(1.5f);
        background.transform.DOMoveY(2000f, 0.5f);
        yield return new WaitForSeconds(0.5f);
        pImg.DOFade(0, 1f);
        yield return new WaitForSeconds(0.5f);
        panel.SetActive(false);
        playerRb.gravityScale = 1;
        boss.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
