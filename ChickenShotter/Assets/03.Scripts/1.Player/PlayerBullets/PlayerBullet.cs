using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Bullet
{

    private int _throughLevel;

    protected override void Awake()
    {

        base.Awake();

        _targetLayer = LayerMask.NameToLayer("Enemy");

    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.layer == _worldGridLayer)
            PoolManager.Instance.Push(this);

        if (collision.gameObject.layer != _targetLayer)
            return;

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
        _bulletDamage = PlayerManager.Instance.CalcPlayerDamage();

        PlayerStat stat = PlayerManager.Instance.GetPlayerStat();
        if(stat != null)
        {

            _throughLevel = stat.GetPlayerStatData().Through;

        }

    }

}
