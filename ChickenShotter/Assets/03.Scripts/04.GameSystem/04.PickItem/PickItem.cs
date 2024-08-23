using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Path;
using UnityEngine;

public abstract class PickItem : PoolableMono
{

    protected Rigidbody2D _rigidbody2D;

    // Default Speed
    private float _speed = 5f;
    private float _pickTime = 1f;

    private bool _isCatch = false;
    public bool IsCatch => _isCatch;

    protected virtual void Awake()
    {

        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.velocity = new Vector2(-_speed, 0f);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.CompareTag("Player"))
        {

            PickItemEffect(collision.transform);
            PoolManager.Instance.Push(this);

        }

    }

    // Parabola Drop
    public void Drop(float power)
    {

        Vector3 randomDir = Random.insideUnitCircle * power;
        transform.DOJump(transform.position + randomDir, power, 1, 0.5f)
            .OnComplete(EndDrop);

    }

    // Catch the Pick Itme, Player Get Item Effect
    public void Catch(Transform playerTrm)
    {

        // Go to Player
        _isCatch = true;
        StartCoroutine(CatchCo(playerTrm));

    }

    IEnumerator CatchCo(Transform playerTrm)
    {

        float currentTime = 0f;
        while (currentTime < _pickTime)
        {

            currentTime += Time.deltaTime;

            Vector2 pos = transform.position;
            Vector2 targetPos = playerTrm.position;

            pos.x = Mathf.Lerp(pos.x, targetPos.x, currentTime / _pickTime);
            pos.y = Mathf.Lerp(pos.y, targetPos.y, currentTime / _pickTime);

            transform.position = pos;

            yield return null;

        }


    }

    private void EndDrop()
    {

        _rigidbody2D.velocity = new Vector2(-_speed, 0f);

    }

    protected abstract void PickItemEffect(Transform playerTrm);

    public override void Reset()
    {
        
        _rigidbody2D.velocity = Vector2.zero;
        _isCatch = false;

    }

}
