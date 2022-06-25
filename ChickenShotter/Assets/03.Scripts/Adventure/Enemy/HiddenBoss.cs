using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;

public class HiddenBoss : PoolableMono
{
    [SerializeField] private float m_Hp = 1; // 체력
    [SerializeField] private float m_MaxHp; // 최대 체력
    [SerializeField] private int m_St = 1; // 공격력
    [SerializeField] private Transform hp_Tr;
    [SerializeField] private GameObject danger;
    [SerializeField] private GameObject dangerLeft;
    [SerializeField] private GameObject dangerRight;

    private BossSound es; // 에너미 사운드 스크립트
    private SpriteRenderer bossSr;
    [SerializeField] private float PatternSpawnTime;

    Rigidbody2D rb;
    StageManager stM;
    PlayerControl pc;
    float rdX, rdY;

    private float rd;
    private void Awake()
    {
        m_Hp = m_MaxHp;
        

        bossSr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        pc = GameObject.Find("PlayerControl").GetComponent<PlayerControl>();
        es = GetComponent<BossSound>();
        stM = GameObject.Find("StageManager").GetComponent<StageManager>();
        stM.ClearTime = 999999999;
        StartCoroutine(BossPatern());
    }
    private void Update()
    {
        FlipX();
    }
    private void FlipX()
    {
        if(transform.position.x <= 0)
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        else
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
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
        scale.x = Mathf.Lerp(0f, 0.5f, (float)m_Hp / m_MaxHp);
        hp_Tr.transform.localScale = scale;
        es.OnDamagedSound();
        yield return new WaitForSeconds(0.1f);
        bossSr.color = Color.white;
        if (m_Hp <= 0)
        {
            m_Hp += 100000;
            bossSr.color = new Color(0, 0, 0, 0);
            for (int i = 0; i < 3; i++)
            {
                es.OnDieSound();
                yield return new WaitForSeconds(0.16f);
            }
            SceneManager.LoadScene("End");

        }
    }
    IEnumerator BossPatern()
    {
        yield return new WaitForSeconds(0.5f);
        while (true)
        {
            rd = Random.Range(0f, 10f);
            //SansH2
            if(rd <= 1.5)
            {
                StartCoroutine(SansH2());
                yield return new WaitForSeconds(6.5f);
            }
            //SansH
            else if (rd <= 3)
            {
                StartCoroutine(SansH());
                yield return new WaitForSeconds(6.5f);
            }
            //낙석1
            else if(rd <= 4.5)
            {
                StartCoroutine(FallingHand());
                yield return new WaitForSeconds(3.5f);
            }
            //낙석2
            else if(rd <= 6)
            {
                StartCoroutine(FallingHand2());
                yield return new WaitForSeconds(4.6f);
            }
            //돌진
            else if(rd <= 8.5)
            {
                StartCoroutine(Dash());
                yield return new WaitForSeconds(2.5f);
            }
            //BulletFire
            else
            {
                StartCoroutine(BulletFire());
                yield return new WaitForSeconds(6.2f);
            }
            yield return new WaitForSeconds(PatternSpawnTime);
        }
    }
    IEnumerator SansH()
    {
        transform.DOMoveY(6.5f, 0.5f);
        dangerRight.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        dangerRight.SetActive(false);
        for(int i = 0; i < 20; i++)
        {
            WallSpawn();
            yield return new WaitForSeconds(0.3f);
        }
    }
    IEnumerator SansH2()
    {
        transform.DOMoveY(6.5f, 0.5f);
        dangerLeft.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        dangerLeft.SetActive(false);
        for (int i = 0; i < 20; i++)
        {
            WallSpawn2();
            yield return new WaitForSeconds(0.3f);
        }
    }
    #region SansH내부코드
    [SerializeField] private float spawnPosX = 10;
    [SerializeField] private float maxPosY = 4.5f;
    [SerializeField] private float minPosY = -4.5f;
    [SerializeField] private string eBullet;
    private void WallSpawn()
    {
        float rd = Random.Range(0f, 10f);
        if (rd <= 2)
        {
            for (int i = 0; i < 5; i++)
            {
                EnemyBullet enemyBullet = PoolManager.Instance.Pop(eBullet) as EnemyBullet;
                enemyBullet.transform.position = new Vector3(spawnPosX, maxPosY - i);
            }
        }
        else if (rd <= 3)
        {
            EnemyBullet enemyBullet2 = PoolManager.Instance.Pop(eBullet) as EnemyBullet;
            enemyBullet2.transform.position = new Vector3(spawnPosX, maxPosY);
            for (int i = 0; i < 4; i++)
            {
                EnemyBullet enemyBullet = PoolManager.Instance.Pop(eBullet) as EnemyBullet;
                enemyBullet.transform.position = new Vector3(spawnPosX, minPosY + i);
            }
        }
        else if (rd <= 4)
        {
            for (int i = 0; i < 4; i++)
            {
                EnemyBullet enemyBullet = PoolManager.Instance.Pop(eBullet) as EnemyBullet;
                enemyBullet.transform.position = new Vector3(spawnPosX, maxPosY - i);
            }
            for (int i = 0; i < 2; i++)
            {
                EnemyBullet enemyBullet = PoolManager.Instance.Pop(eBullet) as EnemyBullet;
                enemyBullet.transform.position = new Vector3(spawnPosX, minPosY + i);
            }
        }
        else if (rd <= 5)
        {
            for (int i = 0; i < 4; i++)
            {
                EnemyBullet enemyBullet = PoolManager.Instance.Pop(eBullet) as EnemyBullet;
                enemyBullet.transform.position = new Vector3(spawnPosX, minPosY + i);
            }
            for (int i = 0; i < 2; i++)
            {
                EnemyBullet enemyBullet = PoolManager.Instance.Pop(eBullet) as EnemyBullet;
                enemyBullet.transform.position = new Vector3(spawnPosX, maxPosY - i);
            }
        }
        else if (rd <= 8)
        {
            for (int i = 0; i < 3; i++)
            {
                EnemyBullet enemyBullet = PoolManager.Instance.Pop(eBullet) as EnemyBullet;
                enemyBullet.transform.position = new Vector3(spawnPosX, minPosY + i);
            }
            for (int i = 0; i < 4; i++)
            {
                EnemyBullet enemyBullet = PoolManager.Instance.Pop(eBullet) as EnemyBullet;
                enemyBullet.transform.position = new Vector3(spawnPosX, maxPosY - i);
            }
        }
        else if (rd <= 9)
        {
            for (int i = 0; i < 4; i++)
            {
                EnemyBullet enemyBullet = PoolManager.Instance.Pop(eBullet) as EnemyBullet;
                enemyBullet.transform.position = new Vector3(spawnPosX, minPosY + i);
            }
            for (int i = 0; i < 3; i++)
            {
                EnemyBullet enemyBullet = PoolManager.Instance.Pop(eBullet) as EnemyBullet;
                enemyBullet.transform.position = new Vector3(spawnPosX, maxPosY - i);
            }
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                EnemyBullet enemyBullet = PoolManager.Instance.Pop(eBullet) as EnemyBullet;
                enemyBullet.transform.position = new Vector3(spawnPosX, minPosY + i);
            }
            for (int i = 0; i < 3; i++)
            {
                EnemyBullet enemyBullet = PoolManager.Instance.Pop(eBullet) as EnemyBullet;
                enemyBullet.transform.position = new Vector3(spawnPosX, maxPosY - i);
            }
        }
    }
    #endregion
    #region SansH2 내부코드
    [SerializeField] private string eBullet2;
    private void WallSpawn2()
    {
        float rd = Random.Range(0f, 10f);
        if (rd <= 2)
        {
            for (int i = 0; i < 5; i++)
            {
                EnemyBullet enemyBullet = PoolManager.Instance.Pop(eBullet2) as EnemyBullet;
                enemyBullet.transform.position = new Vector3(-spawnPosX, maxPosY - i);
            }
        }
        else if (rd <= 3)
        {
            EnemyBullet enemyBullet2 = PoolManager.Instance.Pop(eBullet2) as EnemyBullet;
            enemyBullet2.transform.position = new Vector3(-spawnPosX, maxPosY);
            for (int i = 0; i < 4; i++)
            {
                EnemyBullet enemyBullet = PoolManager.Instance.Pop(eBullet2) as EnemyBullet;
                enemyBullet.transform.position = new Vector3(-spawnPosX, minPosY + i);
            }
        }
        else if (rd <= 4)
        {
            for (int i = 0; i < 4; i++)
            {
                EnemyBullet enemyBullet = PoolManager.Instance.Pop(eBullet2) as EnemyBullet;
                enemyBullet.transform.position = new Vector3(-spawnPosX, maxPosY - i);
            }
            for (int i = 0; i < 2; i++)
            {
                EnemyBullet enemyBullet = PoolManager.Instance.Pop(eBullet2) as EnemyBullet;
                enemyBullet.transform.position = new Vector3(-spawnPosX, minPosY + i);
            }
        }
        else if (rd <= 5)
        {
            for (int i = 0; i < 4; i++)
            {
                EnemyBullet enemyBullet = PoolManager.Instance.Pop(eBullet2) as EnemyBullet;
                enemyBullet.transform.position = new Vector3(-spawnPosX, minPosY + i);
            }
            for (int i = 0; i < 2; i++)
            {
                EnemyBullet enemyBullet = PoolManager.Instance.Pop(eBullet2) as EnemyBullet;
                enemyBullet.transform.position = new Vector3(-spawnPosX, maxPosY - i);
            }
        }
        else if (rd <= 8)
        {
            for (int i = 0; i < 3; i++)
            {
                EnemyBullet enemyBullet = PoolManager.Instance.Pop(eBullet2) as EnemyBullet;
                enemyBullet.transform.position = new Vector3(-spawnPosX, minPosY + i);
            }
            for (int i = 0; i < 4; i++)
            {
                EnemyBullet enemyBullet = PoolManager.Instance.Pop(eBullet2) as EnemyBullet;
                enemyBullet.transform.position = new Vector3(-spawnPosX, maxPosY - i);
            }
        }
        else if (rd <= 9)
        {
            for (int i = 0; i < 4; i++)
            {
                EnemyBullet enemyBullet = PoolManager.Instance.Pop(eBullet2) as EnemyBullet;
                enemyBullet.transform.position = new Vector3(-spawnPosX, minPosY + i);
            }
            for (int i = 0; i < 3; i++)
            {
                EnemyBullet enemyBullet = PoolManager.Instance.Pop(eBullet2) as EnemyBullet;
                enemyBullet.transform.position = new Vector3(-spawnPosX, maxPosY - i);
            }
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                EnemyBullet enemyBullet = PoolManager.Instance.Pop(eBullet2) as EnemyBullet;
                enemyBullet.transform.position = new Vector3(-spawnPosX, minPosY + i);
            }
            for (int i = 0; i < 3; i++)
            {
                EnemyBullet enemyBullet = PoolManager.Instance.Pop(eBullet2) as EnemyBullet;
                enemyBullet.transform.position = new Vector3(-spawnPosX, maxPosY - i);
            }
        }
    }
    #endregion
    IEnumerator BulletFire()
    {
        rdX = Random.Range(-6f, 6f);
        rdY = Random.Range(-3f, 3f);
        danger.SetActive(true);
        danger.transform.position = new Vector2(rdX, rdY);
        yield return new WaitForSeconds(2f);
        danger.SetActive(false);
        transform.DOMove(new Vector2(rdX, rdY), 1f);
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < 64; i++)
        {
            
            EnemyBullet enemyBullet = PoolManager.Instance.Pop("EnemyBullet") as EnemyBullet;
            enemyBullet.transform.position = transform.position;
            enemyBullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, i * 22.5f));
            EnemyBullet enemyBullet2 = PoolManager.Instance.Pop("EnemyBullet") as EnemyBullet;
            enemyBullet2.transform.position = transform.position;
            enemyBullet2.transform.rotation = Quaternion.Euler(new Vector3(0, 0, i * 22.5f + 180));
            yield return new WaitForSeconds(0.05f);
        }


    }
    IEnumerator FallingHand()
    {
        rdX = Random.Range(-6f, 6f);
        rdY = Random.Range(-3f, 3f);
        danger.SetActive(true);
        danger.transform.position = new Vector2(rdX, rdY);
        yield return new WaitForSeconds(2f);
        danger.SetActive(false);
        transform.DOMove(new Vector2(rdX, rdY), 1f);
        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < 6; i++)
        {
            MateoDanger spawnHand = PoolManager.Instance.Pop("downHandDanger") as MateoDanger;
            spawnHand.transform.position = new Vector3(i * 3.16f - 8, -4.5f, 0);
        }
    }
    IEnumerator FallingHand2()
    {
        rdX = Random.Range(-6f, 6f);
        rdY = Random.Range(-3f, 3f);
        danger.SetActive(true);
        danger.transform.position = new Vector2(rdX, rdY);
        yield return new WaitForSeconds(2f);
        danger.SetActive(false);
        transform.DOMove(new Vector2(rdX, rdY), 1f);
        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < 5; i++)
        {
            MateoDanger spawnHand = PoolManager.Instance.Pop("downHandDanger") as MateoDanger;
            spawnHand.transform.position = new Vector3(i * 3.16f - 6.9f, -4.5f, 0);
        }
    }
    IEnumerator Dash()
    {
        for(int i =0; i<2; i++)
        {
            danger.SetActive(true);
            danger.transform.position = GameObject.Find("PlayerControl/PlayerSprite").transform.position;
            yield return new WaitForSeconds(1f);
            danger.SetActive(false);
            transform.DOMove(danger.transform.position, 1f);
            yield return new WaitForSeconds(0.8f);
            if (i == 0)
            {
                for(int j=0; j <4; j++)
                {
                    EnemyBullet enemyBullet = PoolManager.Instance.Pop("EnemyBullet") as EnemyBullet;
                    enemyBullet.transform.position = transform.position;
                    enemyBullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, j * 90f));
                }
            }
            else
            {
                for (int j = 0; j < 4; j++)
                {
                    EnemyBullet enemyBullet = PoolManager.Instance.Pop("EnemyBullet") as EnemyBullet;
                    enemyBullet.transform.position = transform.position;
                    enemyBullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, j * 90f + 45));
                }
            }
        }
        yield return new WaitForSeconds(1f);

    }

    public override void Reset()
    {
        //
    }
}

