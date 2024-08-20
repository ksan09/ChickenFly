using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : PoolableMono
{

    private Rigidbody2D _rigidbody2D;
    private int _targetLayer;

    // 총알 맞았을 때 이펙트
    [Header("Info")]
    [SerializeField] private PoolingParticle _hitEffect;

    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _bulletDamage;

    private void Awake()
    {

        _rigidbody2D = GetComponent<Rigidbody2D>();
        _targetLayer = LayerMask.NameToLayer("Player");

    }

    public void Shoot(Vector2 dir)
    {

        _rigidbody2D.velocity = dir * _bulletSpeed;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.layer != _targetLayer) // 레이어 체크 기능 넣기
        {
            return;
        }

        if (collision.TryGetComponent<HealthObject>(out HealthObject healthObject))
        {

            float damage = _bulletDamage;

            healthObject.OnHit(damage);

            if (_hitEffect != null)
            {

                PoolingParticle hitEffect = PoolManager.Instance.Pop(_hitEffect.name, transform.position, Quaternion.identity) as PoolingParticle;
                hitEffect.PlayParticle();

            }

            PoolManager.Instance.Push(this);

        }

    }

    public override void Reset()
    {



    }

}
