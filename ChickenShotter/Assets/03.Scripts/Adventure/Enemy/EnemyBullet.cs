using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EnemyBullet : PoolableMono
{
    [SerializeField] private int m_St = 1; // °ø°Ý·Â
    PlayerControl pc;
    private void Awake()
    {
        pc = GameObject.Find("PlayerControl").GetComponent<PlayerControl>();
    }
    private void Update()
    {
        if (transform.position.y >= 11 || transform.position.y <= -11 || transform.position.x >= 11 || transform.position.x <= -11)
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.CompareTag("Player"))
        {
            pc.Player_OnDamage(m_St);
            Die();
        }
        else if (obj.CompareTag("Sheild"))
        {
            Die();
        }
    }

    private void Die()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        PoolManager.Instance.Push(this);
    }

    public override void Reset()
    {
        //
    }
}
