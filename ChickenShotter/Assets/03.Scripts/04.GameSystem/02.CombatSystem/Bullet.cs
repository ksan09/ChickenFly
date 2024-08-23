using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : PoolableMono
{

    protected Rigidbody2D   _rigidbody2D;           // ����
    protected int           _targetLayer;           // ��ǥ ���̾�
    protected int           _worldGridLayer;        // ���� ��� ���̾�

    // Bullet Info
    [Header("Info")]
    [SerializeField] protected PoolingParticle      _hitEffect;
    [SerializeField] protected float                _bulletSpeed;
    [SerializeField] protected float                _bulletDamage;

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

    public void Shoot(Vector2 dir)
    {

        _rigidbody2D.velocity = dir * _bulletSpeed;

    }

    public override void Reset()
    {


    }

}
