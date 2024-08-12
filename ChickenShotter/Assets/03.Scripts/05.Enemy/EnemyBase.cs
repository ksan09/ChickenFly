using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{

    private SpriteRenderer _spriteRenderer;
    private Material _material;

    private HealthObject _healthObject;

    private Coroutine _coroutine;
    private WaitForSeconds _wfsHitEffectTime;

    private readonly int HASH_BLINK = Shader.PropertyToID("_StrongTintFade");
    private readonly int HASH_SHAKE = Shader.PropertyToID("_VibrateFade");

    private void Awake()
    {
        
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _material = _spriteRenderer.material;

        _healthObject = GetComponent<HealthObject>();

        _wfsHitEffectTime = new WaitForSeconds(0.02f);
        _healthObject.OnHitEvent += HandleHitEffect;

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


}
