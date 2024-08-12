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

    private void Awake()
    {

        _input              = GetComponent<PlayerInputController>();
        _weapon             = GetComponent<PlayerWeapon>();
        _playerRigidbody    = GetComponent<Rigidbody2D>();
        _animator           = GetComponent<Animator>();

        RegisterInput();    // 플레이어 입력 이벤트 등록
        RegisterEvent();    // 매니저에 이벤트 등록

        StartCoroutine(ShotBulletCo());

    }


    private void RegisterInput()
    {

        _input.OnTouchJumpFunc  += HandleJump;
        _input.OnTouchMoveXFunc += HandleMoveX;

    }

    private void RegisterEvent()
    {

        GameManager.Instance.OnChangeGameModeEvent                  += HandleUpdatePlayerControllerByGameMode;
        PlayerManager.Instance.GetPlayerStat().OnUpdatePlayerStat   += HandleUpdatePlayerContorllerWhenUpdatePlayerStat;

    }

    private void HandleUpdatePlayerControllerByGameMode(Chf_GameMode gameMode)
    {

        if (_playerRigidbody != null)
        {

            switch (gameMode)
            {
                case Chf_GameMode.OnlyPlay:
                    _playerRigidbody.simulated = true;
                    _animator.speed = 1;
                    break;
                case Chf_GameMode.OnlyUI:
                    _playerRigidbody.simulated = false;
                    _animator.speed = 0;
                    break;
            }


        }

    }
    private void HandleUpdatePlayerContorllerWhenUpdatePlayerStat(PlayerStatData lastData, PlayerStatData currentData)
    {

        _jumpPower = currentData.JumpPower;

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

    }

    IEnumerator ShotBulletCo()
    {

        while(true)
        {

            _weapon.Attack();

            yield return new WaitForSeconds(1 / _attackSpeed);
        
        }

    }

}
