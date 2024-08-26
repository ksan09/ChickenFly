using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PoolingAnimation : PoolableMono
{

    Animator _animator;
    
    WaitForSeconds _wfsPlayParticle;
    Coroutine _playAnimationCoroutine;

    private void Awake()
    {

        _animator = GetComponent<Animator>();
        _wfsPlayParticle = new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length);

        PlayAnimation();

    }

    public void PlayAnimation()
    {

        _playAnimationCoroutine = StartCoroutine(PlayAnimationCo());

    }

    IEnumerator PlayAnimationCo()
    {

        _animator.Play(_animator.GetCurrentAnimatorStateInfo(0).GetHashCode());
        yield return _wfsPlayParticle;

        PoolManager.Instance.Push(this);

    }

    public override void Reset()
    {

    }

}
