using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInputController))]
public class PlayerController : MonoBehaviour
{

    private PlayerInputController _input;
    private PlayerWeapon _weapon;

    private Rigidbody2D _playerRigidbody;
    private Animator _animator;

    // Player Value
    [Header("Player Info")]
    [SerializeField] private float _jumpPower = 10f;
    [SerializeField] private float _speed = 4f;

    private float _attackSpeed = 2f;
    private WaitForSeconds _wfsAttackDelay;

    private void Start()
    {

        _input              = GetComponent<PlayerInputController>();
        _weapon             = GetComponent<PlayerWeapon>();
        _playerRigidbody    = GetComponent<Rigidbody2D>();
        _animator           = GetComponent<Animator>();

        RegisterInput();    // 플레이어 입력 이벤트 등록
        RegisterEvent();    // 매니저에 이벤트 등록

        PlayerStatData data = PlayerManager.Instance.GetPlayerStat().GetPlayerStatData();
        HandleUpdatePlayerContorllerWhenUpdatePlayerStat(data, data);

        StartCoroutine(ShotBulletCo());

    }


    private void RegisterInput()
    {

        _input.OnTouchJumpFunc  += HandleJump;
        _input.OnTouchMoveXFunc += HandleMoveX;

    }

    private void RegisterEvent()
    {

        PlayerManager.Instance.GetPlayerStat().OnUpdatePlayerStat   += HandleUpdatePlayerContorllerWhenUpdatePlayerStat;

    }

    private void HandleUpdatePlayerContorllerWhenUpdatePlayerStat(PlayerStatData lastData, PlayerStatData currentData)
    {

        _jumpPower = currentData.JumpPower;
        _attackSpeed = currentData.AttackSpeed;

        _wfsAttackDelay = new WaitForSeconds(1 / _attackSpeed);

    }

    private void HandleJump()
    {

        if (_playerRigidbody.velocity.y > 5f)
            return;

        Vector3 velocity = _playerRigidbody.velocity;
        velocity.y = 0;
        _playerRigidbody.velocity = velocity;
        _playerRigidbody.AddForce(Vector3.up * _jumpPower, ForceMode2D.Impulse);

    }

    private void HandleMoveX(float dir)
    {

        dir = Mathf.Clamp(dir, -1, 1);
        Vector3 velocity = _playerRigidbody.velocity;
        velocity.x = dir * _speed;

        _playerRigidbody.velocity = velocity;

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -13f, 12f), transform.position.y, 0);

    }

    IEnumerator ShotBulletCo()
    {

        while(true)
        {

            _weapon.Attack();

            yield return _wfsAttackDelay;
        
        }

    }

}
