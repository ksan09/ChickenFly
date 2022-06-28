using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rb; //플레이어 리지드바디
    private Transform tr; //플레이어 트랜스폼
    private SpriteRenderer sr; // 플레이어 스프라이트 렌더러
    private PlayerSound ps; // 플레이어 사운드 스크립트
    [SerializeField] private GameObject bulletPrefab; //총알
    [SerializeField] private GameObject firePos; //발사위치
    [SerializeField] private Vector3 jumpForce = new Vector3(0, 0, 0); // 점프힘
    [SerializeField] private Vector3 juumpForce = new Vector3(0, 0, 0); // 롱 점프 주어지는 힘
    [SerializeField] private float maxJuumpTime = 0.15f;
    [SerializeField] private float addForceJump = 4;
    private bool isJump;
    private float angle = 2;
    private float juumpTime = 0;
    private float p_Speed = 0;
    private bool damagedCool = true;
    int i;

    private void Awake()
    {
        rb = transform.GetChild(0).GetComponent<Rigidbody2D>();
        tr = transform.GetChild(0).GetComponent<Transform>();
        sr = transform.GetChild(0).GetComponent<SpriteRenderer>();
        ps = GetComponent<PlayerSound>();
    }
    private void Start()
    {
        StartCoroutine("BulletFire");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
        {
            if (isJump == false)
                Jump();
            i = 0;
        }
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space))
        {

            Juump();
        }

        Move();
        CheckPlayer();

    }
    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0, 0);
        rb.AddForce(jumpForce, ForceMode2D.Impulse);
        ps.JumpSound();
        isJump = true;
        juumpTime = 0;
    }
    private void Juump()
    {
        if (juumpTime <= maxJuumpTime && isJump == true)
        {
            juumpTime += Time.deltaTime;
            rb.AddForce(juumpForce* addForceJump*Time.deltaTime, ForceMode2D.Force);
        }
    }
    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        p_Speed = x * PlayerManager.Instance.PlayerSpeed;

        Vector3 dir = new Vector3(p_Speed, rb.velocity.y, 0);
        rb.velocity = dir;
        if (x < 0)
            tr.rotation = Quaternion.Euler(0, 180, 0);
        else if (x > 0)
            tr.rotation = Quaternion.Euler(0, 0, 0);
    }
    private void CheckPlayer()
    {
        rb.transform.position = new Vector3(Mathf.Clamp(rb.transform.position.x, -9, 9), Mathf.Clamp(rb.transform.position.y, -5.5f, 5), 0);
        if (rb.transform.position.y == -5.5)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, 0);
            rb.transform.position = new Vector3(rb.transform.position.x, -5.49f, 0);
            rb.AddForce(new Vector3(0, 8, 0), ForceMode2D.Impulse);
            StartCoroutine(P_OnDamage(1));

        }
        if (rb.transform.position.y == 5)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, 0);
        }
        if (PlayerManager.Instance.PlayerCurrentHealth <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        if (rb.velocity.y <= 2)
        {
            isJump = false;
        }

    }
    IEnumerator BulletFire()
    {
        while (true)
        {
            for (float i = 0; i < PlayerManager.Instance.PlayerBulletNum; i++)
            {
                // y = PosY에서 +1하고 -0.5-0.5-0.5-0.5순으로 소환되는 느낌으로 되야한다. 그럴 때 a는 5 그러면 a/2-1에서 - a/(2*a)?
                if (PlayerManager.Instance.PlayerBulletNum % 2 == 0) //짝수
                {
                    BulletDestroy egg = PoolManager.Instance.Pop("Bullet") as BulletDestroy;
                    egg.transform.position = firePos.transform.position;
                    egg.transform.rotation = Quaternion.Euler(tr.rotation.x, tr.rotation.y * 180, tr.rotation.z + PlayerManager.Instance.PlayerBulletNum / 2 * angle - i * angle - angle/2);
                }
                    
                else //홀수
                {
                    BulletDestroy egg = PoolManager.Instance.Pop("Bullet") as BulletDestroy;
                    egg.transform.position = firePos.transform.position;
                    egg.transform.rotation = Quaternion.Euler(tr.rotation.x, tr.rotation.y * 180, tr.rotation.z + PlayerManager.Instance.PlayerBulletNum / 2 * angle - i * angle);
                }

            }
            yield return new WaitForSeconds(0.2f);
        }
    }
    public void Player_OnDamage(int dmg)
    {
        if(damagedCool)
            StartCoroutine(P_OnDamage(dmg));
    }
    IEnumerator P_OnDamage(int dmg)
    {
        damagedCool = false;
        PlayerManager.Instance.PlayerCurrentHealth -= dmg;
        ps.DamagedSound();
        sr.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sr.color = Color.white;
        damagedCool = true;
    }
}
