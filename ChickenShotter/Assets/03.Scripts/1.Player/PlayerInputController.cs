using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{

    private GameManager _gameManager;
    public event Action OnTouchJumpFunc;
    public event Action<float> OnTouchMoveXFunc;

    private void Awake()
    {

        _gameManager = GameManager.Instance;

    }

    private void Update()
    {

        // UI Mode라면 플레이가 진행되지 않는다
        if (_gameManager.GameMode == Chf_GameMode.OnlyUI)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {

            OnTouchJumpFunc?.Invoke();

        }

        OnTouchMoveXFunc?.Invoke(0);
        if (Input.GetKey(KeyCode.A))
        {

            OnTouchMoveXFunc?.Invoke(-1f);

        }
        if (Input.GetKey(KeyCode.D))
        {

            OnTouchMoveXFunc?.Invoke(1);

        }

    }


}
