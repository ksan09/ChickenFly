using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PoolingParticle : PoolableMono
{

    ParticleSystem _particleSystem;
    WaitUntil _waitUntilStopParticle;
    Coroutine _playParticleCoroutine;

    private void Awake()
    {
        
        _particleSystem = GetComponent<ParticleSystem>();
        _waitUntilStopParticle = new WaitUntil(() =>
        {
            return _particleSystem.isStopped;
        });

    }

    public void PlayParticle()
    {

        _playParticleCoroutine = StartCoroutine(PlayParticleCo());

    }

    IEnumerator PlayParticleCo()
    {

        _particleSystem.Play();
        yield return _waitUntilStopParticle;

        _particleSystem.Stop();
        PoolManager.Instance.Push(this);

    }

    public override void Reset()
    {
        
    }

}
