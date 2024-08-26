using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyBase : PoolableMono
{

    [Header("Stat")]
    [SerializeField] protected float _strength    = 10f;
    [SerializeField] protected float _speed       = 6f;
    [SerializeField] protected float _maxHealth   = 50;

    [Header("Drop Heart Value")]
    [SerializeField] private int _minDropHeart = 1;
    [SerializeField] private int _maxDropHeart = 2;

    [Header("Drop Exp Value")]
    [SerializeField] private float _expValue = 0.5f;

    [SerializeField] private int _minDropExp = 2;
    [SerializeField] private int _maxDropExp = 5;

    protected Rigidbody2D _rigidbody2D;

    private SpriteRenderer _spriteRenderer;
    private Material _material;

    private HealthObject _healthObject;

    private Coroutine _coroutine;
    private WaitForSeconds _wfsHitEffectTime;

    private readonly int HASH_BLINK = Shader.PropertyToID("_StrongTintFade");
    private readonly int HASH_SHAKE = Shader.PropertyToID("_VibrateFade");

    private void Awake()
    {
        
        _rigidbody2D = GetComponent<Rigidbody2D>();

        _spriteRenderer = GetComponent<SpriteRenderer>();
        _material = _spriteRenderer.material;

        _healthObject = GetComponent<HealthObject>();
        _healthObject.OnDieEvent += HandleDie;

        _healthObject.Init(_maxHealth);

        _wfsHitEffectTime = new WaitForSeconds(0.05f);
        _healthObject.OnHitEvent += HandleHitEffect;

    }

    protected virtual void Update()
    {

        if (transform.position.x < -20f)
            PoolManager.Instance.Push(this);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.CompareTag("Player"))
        {

            float damage = PlayerManager.Instance.CalcPlayerHitDamage(_strength);
            PlayerManager.Instance.GetPlayerHealth().OnHit(damage);

            _healthObject.OnHit(1f);
            _rigidbody2D.velocity = _rigidbody2D.velocity * 1.5f;

        }

    }

    private void HandleHitEffect()
    {

        if (gameObject.activeInHierarchy == false)
            return;

        if(_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(HitEffectCo());

    }

    IEnumerator HitEffectCo()
    {

        _material.SetFloat(HASH_BLINK, 1f);
        _material.SetFloat(HASH_SHAKE, 1f);

        yield return _wfsHitEffectTime;

        _material.SetFloat(HASH_BLINK, 0f);
        _material.SetFloat(HASH_SHAKE, 0f);
        _coroutine = null;

    }

    private void HandleDie()
    {

        int randomDropCount = Random.Range(_minDropHeart, _maxDropHeart + 1);
        for(int i = 0; i < randomDropCount; ++i)
        {

            Heart heartObj = PoolManager.Instance.Pop("Heart", transform.position, Quaternion.identity) as Heart;
            if (heartObj != null)
            {
                heartObj.Drop(2f);
            }

        }

        randomDropCount = Random.Range(_minDropExp, _maxDropExp + 1);
        for (int i = 0; i < randomDropCount; ++i)
        {

            ExpBlock expBlock = PoolManager.Instance.Pop("ExpBlock", transform.position, Quaternion.identity) as ExpBlock;
            if (expBlock != null)
            {

                expBlock.Drop(1.5f);
                expBlock.SetExpBlockValue(_expValue);

            }

        }


        PoolManager.Instance.Push(this);
        PlayerManager.Instance.KillEnemy(transform);

    }

    public override void Reset()
    {

        _rigidbody2D.velocity = new Vector3(-UnityEngine.Random.Range(_speed - 0.5f, _speed + 0.5f), 0);
        _healthObject.Init(_maxHealth);

        _material.SetFloat(HASH_BLINK, 0f);
        _material.SetFloat(HASH_SHAKE, 0f);
        _coroutine = null;

    }
}
