using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : PoolableMono
{

    private Rigidbody2D _rigidbody2D;
    private int _targetLayer;

    private int _throughLevel;

    // �Ѿ� �¾��� �� ����Ʈ
    [Header("Info")]
    [SerializeField] private PoolingParticle _hitEffect;

    [SerializeField] private float _bulletSpeed;

    private void Awake()
    {

        _rigidbody2D = GetComponent<Rigidbody2D>();
        _targetLayer = LayerMask.NameToLayer("Enemy");

    }

    public void Shoot(Vector2 dir)
    {

        _rigidbody2D.velocity = dir * _bulletSpeed;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.layer != _targetLayer) // ���̾� üũ ��� �ֱ�
        {
            return;
        }

        if(collision.TryGetComponent<HealthObject>(out HealthObject healthObject))
        {

            float damage = PlayerManager.Instance.CalcPlayerDamage();

            healthObject.OnHit(damage);

            if(_hitEffect != null)
            {

                PoolingParticle hitEffect = PoolManager.Instance.Pop(_hitEffect.name, transform.position, Quaternion.identity) as PoolingParticle;
                hitEffect.PlayParticle();

            }

            _throughLevel--;
            if(_throughLevel < 0)
            {

                PoolManager.Instance.Push(this);

            }

        }

    }

    public override void Reset()
    {

        _throughLevel = 0;

        PlayerStat stat = PlayerManager.Instance.GetPlayerStat();
        if(stat != null)
        {

            _throughLevel = stat.GetPlayerStatData().Through;

        }

    }

}
