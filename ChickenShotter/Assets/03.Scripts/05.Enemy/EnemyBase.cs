using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : PoolableMono
{

    [Header("Stat")]
    [SerializeField] private float _speed       = 6;
    [SerializeField] private float _maxHealth   = 50;

    private Rigidbody2D _rigidbody2D;

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

        _wfsHitEffectTime = new WaitForSeconds(0.05f);
        _healthObject.OnHitEvent += HandleHitEffect;

    }

    private void Update()
    {

        if (transform.position.x < -20f)
            PoolManager.Instance.Push(this);

    }

    private void HandleHitEffect()
    {

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

        PoolManager.Instance.Push(this);
        PlayerManager.Instance.KillEnemy();

    }

    public override void Reset()
    {

        _rigidbody2D.velocity = new Vector3(-_speed, 0);
        _healthObject.Init(_maxHealth);

        _material.SetFloat(HASH_BLINK, 0f);
        _material.SetFloat(HASH_SHAKE, 0f);
        _coroutine = null;

    }
}
