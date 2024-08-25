using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemy : EnemyBase
{

    [Header("Range Enemy Info")]
    [SerializeField] private float _stopX;
    [SerializeField] private float _marginOfError = 1f;
    private bool _isStop = false;

    private float _currentStopX;

    [Header("Range Attack Info")]
    [SerializeField] private float _shotDelay = 1f;
    [SerializeField] private float _bulletSpeed = 10f;
    [SerializeField] private EnemyBullet _bullet;

    [SerializeField] private bool _useAutoTargeting = true; // 플레이어를 조준하여 발사할 것인가

    private WaitForSeconds _wfsShotDelay;
    protected Transform _playerTransform;

    private void Start()
    {
        
        _playerTransform = PlayerManager.Instance.GetPlayerTransform();

        _wfsShotDelay = new WaitForSeconds(_shotDelay);

    }

    protected override void Update()
    {

        if (_isStop)
            return;

        base.Update();

        if(transform.position.x <= _currentStopX)
        {

            Debug.Log("Check");

            _isStop = true;
            _rigidbody2D.velocity = Vector3.zero;

            StartCoroutine(ShotLoopCo());

        }

    }

    protected virtual void ShotBullet()
    {

        Vector2 dir = Vector2.left;

        if (_useAutoTargeting)
            dir = (_playerTransform.position - transform.position).normalized;

        EnemyBullet bullet = PoolManager.Instance.Pop(_bullet.name, transform.position, Quaternion.identity) as EnemyBullet;
        bullet.Shoot(dir, _strength, _bulletSpeed);

    }

    IEnumerator ShotLoopCo()
    {

        while(true)
        {

            ShotBullet();

            yield return _wfsShotDelay;

        }

    }

    public override void Reset()
    {

        base.Reset();

        _isStop = false;
        _currentStopX = _stopX + Random.Range(-_marginOfError, _marginOfError);

    }

}
