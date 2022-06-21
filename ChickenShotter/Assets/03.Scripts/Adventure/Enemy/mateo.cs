using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class mateo : PoolableMono
{
    [SerializeField] private int m_St = 1; // °ø°Ý·Â
    [SerializeField] private Movement m_Mv;
    private SpriteRenderer p_Sr;
    PlayerControl pc;
    private void Awake()
    {
        p_Sr = GameObject.Find("PlayerControl/PlayerSprite").GetComponent<SpriteRenderer>();
        m_Mv = GetComponent<Movement>();
        pc = GameObject.Find("PlayerControl").GetComponent<PlayerControl>();
    }
    private void Update()
    {
        if(transform.position.y < -5)
        {
            PoolManager.Instance.Push(this);
        }
    }

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.CompareTag("Player"))
        {
            pc.Player_OnDamage(m_St);
        }
    }
    public override void Reset()
    {
        //
    }
}
