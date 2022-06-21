using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Enemy : PoolableMono
{
    [SerializeField] private int m_Hp = 1; // 체력
    [SerializeField] private int m_St = 1; // 공격력
    [SerializeField] private int m_DropMoney = 2; // 떨어트리는 돈
    [SerializeField] private TextMeshProUGUI MoneyTxt;
    [SerializeField] private Movement m_Mv;
    private EnemySound es; // 에너미 사운드 스크립트
    private SpriteRenderer p_Sr;
    private SpriteRenderer m_Sr;
    PlayerControl pc;
    private void Awake()
    {
        MoneyTxt = GameObject.Find("Canvas/Money").GetComponent<TextMeshProUGUI>();
        p_Sr = GameObject.Find("PlayerControl/PlayerSprite").GetComponent<SpriteRenderer>();
        m_Sr = GetComponent<SpriteRenderer>();
        m_Mv = GetComponent<Movement>();
        pc = GameObject.Find("PlayerControl").GetComponent<PlayerControl>();
        es = GetComponent<EnemySound>();
    }
    

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if(obj.CompareTag("Player"))
        {
            m_Hp = 0;
            pc.Player_OnDamage(m_St);
            StartCoroutine(M_OnDamage());
        }
        else if(obj.CompareTag("Bullet"))
        {
            m_Hp -= PlayerManager.Instance.PlayerStrength;
            if (m_Hp <= 0)
            {
                PlayerManager.Instance.Money += m_DropMoney;
                MoneyTxt.text = $"{PlayerManager.Instance.Money}";
            }
            StartCoroutine(M_OnDamage());
            StartCoroutine(OnEffect(m_Sr));

        }
        else
        {
            PoolManager.Instance.Push(this);
        }
    }
    IEnumerator M_OnDamage()
    {
        m_Sr.color = Color.red;
        es.OnDamagedSound();
        yield return new WaitForSeconds(0.1f);
        m_Sr.color = Color.white;
        if (m_Hp <= 0)
            PoolManager.Instance.Push(this);
    }
    
    IEnumerator OnEffect(SpriteRenderer sr)
    {
        float saveSpeed = m_Mv.Speed;
        if (PlayerManager.Instance.Electric > 0)
        {
            float rd = Random.Range(0f, 100f);
            if (rd < PlayerManager.Instance.Electric * 0.2f)
            {
                sr.color = Color.yellow;
                m_Mv.Speed = 0;
            }
        }
        if (PlayerManager.Instance.Ice > 0)
        {
            m_Mv.Speed -= PlayerManager.Instance.Ice * 0.1f;
            m_Sr.color = new Color(0.25f, 0.8f, 0.9f);
        }
        Color saveColor = sr.color;
        if (PlayerManager.Instance.Fire > 0)
        {
            for (int i = 0; i < 10; i++)
            {
                m_Hp -= PlayerManager.Instance.Fire;
                sr.color = Color.red;
                yield return new WaitForSeconds(0.1f);
                sr.color = saveColor;
                yield return new WaitForSeconds(0.1f);
            }
        }
        else
            yield return new WaitForSeconds(1f);
        m_Mv.Speed = saveSpeed;
        m_Mv.Speed += PlayerManager.Instance.Ice * 0.1f;
        m_Sr.color = Color.white;
    }

    public override void Reset()
    {
        //
    }
}
