using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Boss : PoolableMono
{
    [SerializeField] private int m_Hp = 1; // 체력
    [SerializeField] private int m_St = 1; // 공격력
    [SerializeField] private int m_DropMoney = 2; // 떨어트리는 돈
    [SerializeField] private TextMeshProUGUI MoneyTxt;
    private EnemySound es; // 에너미 사운드 스크립트
    private SpriteRenderer p_Sr;
    private SpriteRenderer m_Sr;

    [SerializeField] private float mateoSpawnTime;

    StageManager stM;
    PlayerControl pc;
    private void Awake()
    {
        MoneyTxt = GameObject.Find("Canvas/Money").GetComponent<TextMeshProUGUI>();
        p_Sr = GameObject.Find("PlayerControl/PlayerSprite").GetComponent<SpriteRenderer>();
        m_Sr = GetComponent<SpriteRenderer>();
        pc = GameObject.Find("PlayerControl").GetComponent<PlayerControl>();
        es = GetComponent<EnemySound>();
        stM = GameObject.Find("StageManager").GetComponent<StageManager>();
        stM.ClearTime = 999999999;
        StartCoroutine(SpawnMateo());

    }


    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.CompareTag("Player"))
        {
            pc.Player_OnDamage(m_St);
        }
        else if (obj.CompareTag("Bullet"))
        {
            m_Hp -= PlayerManager.Instance.PlayerStrength;
            StartCoroutine(M_OnDamage());

        }
    }
    IEnumerator M_OnDamage()
    {

        m_Sr.color = Color.red;
        es.OnDamagedSound();
        yield return new WaitForSeconds(0.1f);
        m_Sr.color = Color.white;
        if (m_Hp <= 0)
        {
            PlayerManager.Instance.Money += m_DropMoney;
            MoneyTxt.text = $"{PlayerManager.Instance.Money}";
            m_Sr.color = new Color(0, 0, 0, 0);
            yield return new WaitForSeconds(0.5f);
            stM.CurrentStage++;
            PlayerPrefs.SetInt("crtStage", stM.CurrentStage);
            SceneManager.LoadScene("GetCard");

        } 
    }
    IEnumerator SpawnMateo()
    {
        while (true)
        {
            float mateoX = Random.Range(-8.5f, 8.5f);
            yield return new WaitForSeconds(mateoSpawnTime);
            MateoDanger mateoDanger = PoolManager.Instance.Pop("DangerMateo") as MateoDanger;
            mateoDanger.transform.position = new Vector3(mateoX, 4.5f, 0);
        }
    }

    public override void Reset()
    {
        //
    }
}
