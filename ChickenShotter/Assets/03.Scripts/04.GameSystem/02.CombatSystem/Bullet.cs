using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : PoolableMono
{

    protected Rigidbody2D   _rigidbody2D;           // 물리
    protected int           _targetLayer;           // 목표 레이어
    protected int           _worldGridLayer;        // 월드 경계 레이어

    // Bullet Info
    [Header("Info")]
    [SerializeField] protected PoolingParticle      _hitEffect;
    [SerializeField] protected float                _bulletSpeed;
    [SerializeField] protected float                _bulletDamage;

    private float _currentBulletDamage;

    protected virtual void Awake()
    {

        _rigidbody2D = GetComponent<Rigidbody2D>();
        _targetLayer = LayerMask.NameToLayer("Player");      
        _worldGridLayer = LayerMask.NameToLayer("WorldGrid");

    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {

        // Check Layer
        if (collision.gameObject.layer == _worldGridLayer)
            PoolManager.Instance.Push(this);

        if (collision.gameObject.layer != _targetLayer)
            return;

        if (collision.TryGetComponent<HealthObject>(out HealthObject healthObject))
        {

            float damage = _currentBulletDamage;
            if (collision.CompareTag("Player"))
                damage = PlayerManager.Instance.CalcPlayerHitDamage(_currentBulletDamage);

            healthObject.OnHit(damage);

            if (_hitEffect != null)
            {

                PoolingParticle hitEffect = PoolManager.Instance.Pop(_hitEffect.name, transform.position, Quaternion.identity) as PoolingParticle;
                hitEffect.PlayParticle();

            }

            PoolManager.Instance.Push(this);

        }

    }

    public void Shoot(Vector2 dir)
    {

        _rigidbody2D.velocity = dir * _bulletSpeed;

    }

    public void Shoot(Vector2 dir, float damage, float speed)
    {

        _currentBulletDamage = damage;
        _rigidbody2D.velocity = dir * speed;

    }

    public override void Reset()
    {

        _currentBulletDamage = _bulletDamage;

    }

}
