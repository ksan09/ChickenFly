using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Enemy : PoolableMono
{
    [SerializeField] private float m_Hp = 1; // 체력
    [SerializeField] private int m_St = 1; // 공격력
    [SerializeField] private int m_DropMoney = 2; // 떨어트리는 돈
    [SerializeField] private TextMeshProUGUI MoneyTxt;
    [SerializeField] private Movement m_Mv;
    private EnemySound es; // 에너미 사운드 스크립트
    private SpriteRenderer p_Sr;
    private SpriteRenderer m_Sr;
    PlayerControl pc;
    float saveSpeed;

    private void Awake()
    {
        MoneyTxt = GameObject.Find("Canvas/CrtPanel/Money").GetComponent<TextMeshProUGUI>();
        p_Sr = GameObject.Find("PlayerControl/PlayerSprite").GetComponent<SpriteRenderer>();
        m_Sr = GetComponent<SpriteRenderer>();
        m_Mv = GetComponent<Movement>();
        pc = GameObject.Find("PlayerControl").GetComponent<PlayerControl>();
        es = GetComponent<EnemySound>();
        saveSpeed = m_Mv.Speed;
    }
    private void OnTriggerEnter2D(Collider2D obj)
    {
        if(obj.CompareTag("Player"))
        {
            pc.Player_OnDamage(m_St);
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            m_Mv.Speed = saveSpeed;
            m_Sr.color = Color.white;
            PoolManager.Instance.Push(this);
        }
        else if(obj.CompareTag("Bullet"))
        {
            BulletDamage(PlayerManager.Instance.PlayerStrength);
        }
        else
        {
            Die();
        }
    }
    public void BulletDamage(float damage)
    {
        m_Hp -= damage;
        StopCoroutine("M_OnDamage");
        StartCoroutine("M_OnDamage");
    }
    IEnumerator M_OnDamage()
    {
        m_Sr.color = Color.red;
        es.OnDamagedSound();
        yield return new WaitForSeconds(0.05f);
        if (m_Hp <= 0)
        {
            Die();
        }
        yield return new WaitForSeconds(0.05f);
        m_Sr.color = Color.white;
        StartCoroutine(OnEffect(m_Sr));
    }
    IEnumerator OnEffect(SpriteRenderer sr)
    {
        
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
            m_Mv.Speed -= PlayerManager.Instance.Ice * 0.2f;
            m_Sr.color = new Color(0.25f, 0.8f, 0.9f);
        }
        Color saveColor = sr.color;
        if (PlayerManager.Instance.Fire > 0)
        {
            for (int i = 0; i < 4; i++)
            {
                m_Hp -= PlayerManager.Instance.Fire;
                sr.color = Color.red;
                yield return new WaitForSeconds(0.1f);
                if(m_Hp <= 0)
                {
                    Die();
                }
                sr.color = saveColor;
                yield return new WaitForSeconds(0.15f);
                
            }
        }
        else
        {
            yield return new WaitForSeconds(0.5f);
        }
        m_Mv.Speed = saveSpeed;
        m_Sr.color = Color.white;
    }
    private void Die()
    {
        m_Sr.color = Color.white;
        PlayerManager.Instance.Money += m_DropMoney;
        MoneyTxt.text = $"{PlayerManager.Instance.Money}";
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        m_Mv.Speed = saveSpeed;
        m_Sr.color = Color.white;
        PoolManager.Instance.Push(this);
    }

    public override void Reset()
    {
        //
    }
}
