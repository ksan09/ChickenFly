using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerObject : PoolableMono
{

    [Header("Info")]
    [SerializeField] private string _spawnObjectName;
    private float _spawnDelay = 2f;

    private Coroutine _spawnCoroutine;

    public void Init(string spawnObject, float spawnDelay = 2f)
    {

        _spawnObjectName = spawnObject;
        _spawnDelay = spawnDelay;

        if (_spawnCoroutine != null)
            StopCoroutine(_spawnCoroutine);

        _spawnCoroutine = StartCoroutine(ObjectSpawnCo());

    }

    private IEnumerator ObjectSpawnCo()
    {

        transform.localScale = new Vector3(1, 0, 1);

        transform.DOKill();
        transform.DOScaleY(1f, 0.5f);

        yield return new WaitForSeconds(_spawnDelay);

        EnemyBullet bullet = 
            PoolManager.Instance.Pop(_spawnObjectName, transform.position, Quaternion.identity) as EnemyBullet;
        bullet.Shoot(Vector2.left);

        transform.DOScaleY(0f, 0.1f)
            .OnComplete(() =>
            {

                PoolManager.Instance.Push(this);

            });

        _spawnCoroutine = null;

    }

    public override void Reset()
    {

        _spawnCoroutine = null;

    }

}
