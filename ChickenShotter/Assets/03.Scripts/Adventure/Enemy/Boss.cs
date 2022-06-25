using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Boss : PoolableMono
{
    [SerializeField] private float m_Hp; // 체력
    [SerializeField] private float m_MaxHp; // 최대 체력
    [SerializeField] private int m_St = 1; // 공격력
    [SerializeField] private int m_DropMoney = 2; // 떨어트리는 돈
    [SerializeField] private TextMeshProUGUI MoneyTxt;
    [SerializeField] private Transform hp_Tr;
    private BossSound es; // 에너미 사운드 스크립트
    private SpriteRenderer bossSr;
    [SerializeField] private SpriteRenderer danger;
    [SerializeField] private float dashCoolTime;
    [SerializeField] private float bulletCoolTime;
    [SerializeField] private float mateoSpawnTime;
    [SerializeField] private string dangerMateo;

    Rigidbody2D rb;
    StageManager stM;
    PlayerControl pc;
    private void Awake()
    {
        m_Hp = m_MaxHp;
        MoneyTxt = GameObject.Find("Canvas/Money").GetComponent<TextMeshProUGUI>();
        
        bossSr = GetComponent<SpriteRenderer>();
        rb= GetComponent<Rigidbody2D>();
        pc = GameObject.Find("PlayerControl").GetComponent<PlayerControl>();
        es = GetComponent<BossSound>();
        stM = GameObject.Find("StageManager").GetComponent<StageManager>();
        stM.ClearTime = 9999999;
        StartCoroutine(SpawnMateo());
        StartCoroutine(BossPatern());
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
    public void DamagedLaser(float damage)
    {
        m_Hp -= damage;
        StartCoroutine(M_OnDamage());
    }
    IEnumerator M_OnDamage()
    {

        bossSr.color = Color.red;
        Vector3 scale = hp_Tr.transform.localScale;
        scale.x = Mathf.Lerp(0f,0.5f, (float)m_Hp / m_MaxHp);
        hp_Tr.transform.localScale = scale;
        es.OnDamagedSound();
        yield return new WaitForSeconds(0.1f);
        bossSr.color = Color.white;
        if (m_Hp <= 0)
        {
            m_Hp += 100000;
            PlayerManager.Instance.Money += m_DropMoney;
            MoneyTxt.text = $"{PlayerManager.Instance.Money}";
            bossSr.color = new Color(0, 0, 0, 0);
            for(int i = 0; i < 3; i++)
            {
                es.OnDieSound();
                yield return new WaitForSeconds(0.16f);
            }
            PlayerManager.Instance.PlayerCurrentHealth = PlayerManager.Instance.PlayerMaxHealth;
            stM.CrtTime = stM.ClearTime;
        } 
    }
    IEnumerator SpawnMateo()
    {
        while (true)
        {
            float mateoX = Random.Range(-8.5f, 8.5f);
            yield return new WaitForSeconds(mateoSpawnTime);
            MateoDanger mateoDanger = PoolManager.Instance.Pop(dangerMateo) as MateoDanger;
            mateoDanger.transform.position = new Vector3(mateoX, -4.1f, 0);
        }
    }
    IEnumerator BossPatern()
    {
        yield return new WaitForSeconds(1.5f);
        while (true)
        {
            for(int j=0; j<3; j++)
            {
                float rd = Random.Range(0, 10f);
                if (rd < 6)
                {
                    if (transform.position.x <= 0)
                        StartCoroutine(DashRight());
                    else
                        StartCoroutine(DashLeft());
                    yield return new WaitForSeconds(1.5f + dashCoolTime);

                }
                else if (rd < 7)
                {
                    if (transform.position.x <= 0)
                    {
                        StartCoroutine(DashRight());
                        yield return new WaitForSeconds(2f);
                        StartCoroutine(DashLeft());
                    }
                    else
                    {
                        StartCoroutine(DashLeft());
                        yield return new WaitForSeconds(2f);
                        StartCoroutine(DashRight());
                    }
                    yield return new WaitForSeconds(3f + dashCoolTime);

                }
                else if (rd < 8)
                {
                    if (transform.position.x <= 0)
                        StartCoroutine(DashRight());
                    else
                        StartCoroutine(DashLeft());
                    for (int i = 0; i < 6; i++)
                    {
                        BulletFire();
                        yield return new WaitForSeconds(0.5f);
                    }
                    yield return new WaitForSeconds(1.5f + dashCoolTime + bulletCoolTime);

                }
                else
                {
                    for (int i = 0; i < 3; i++)
                    {
                        BulletFire();
                        yield return new WaitForSeconds(0.5f);
                    }

                    yield return new WaitForSeconds(bulletCoolTime);
                }
            }
            yield return new WaitForSeconds(1.5f);
            
        }
    }
    IEnumerator DashRight()
    {
        float rdY = Random.Range(-4.1f, 3.5f);
        float outX = 11f;
        rb.velocity = new Vector3(0, 50, 0);
        yield return new WaitForSeconds(0.3f);
        rb.velocity = Vector2.zero;
        transform.position = new Vector3(-outX, rdY, 0);
        danger.color = new Color(1, 0, 0, 0.5f);
        yield return new WaitForSeconds(0.5f);
        danger.color = new Color(1, 0, 0, 0);
        rb.velocity = new Vector3(20, 0, 0);
        yield return new WaitForSeconds(0.9f);
        rb.velocity = Vector2.zero;
        bossSr.flipX = false; 
    }
    IEnumerator DashLeft()
    {
        float rdY = Random.Range(-4.1f, 3.5f);
        float outX = 11f;
        rb.velocity = new Vector3(0, 50, 0);
        yield return new WaitForSeconds(0.3f);
        rb.velocity = Vector2.zero;
        transform.position = new Vector3(outX, rdY, 0);
        danger.color = new Color(1, 0, 0, 0.5f);
        yield return new WaitForSeconds(0.5f);
        danger.color = new Color(1, 0, 0, 0);
        rb.velocity = new Vector3(-20, 0, 0);
        yield return new WaitForSeconds(0.9f);
        rb.velocity = Vector2.zero;
        bossSr.flipX = true;

    }
    private void BulletFire()
    {
        for(int i = 0; i < 360; i += 30)
        {
            es.OnDamagedSound();
            EnemyBullet enemyBullet = PoolManager.Instance.Pop("EnemyBullet") as EnemyBullet;
            enemyBullet.transform.position = transform.position;
            enemyBullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, i));
        }
        

    }

    public override void Reset()
    {
        //
    }
}
