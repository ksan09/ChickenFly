using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInputController : MonoBehaviour
{

    private GameManager _gameManager;
    public event Action OnTouchJumpFunc;
    public event Action<float> OnTouchMoveXFunc;

    private IngameButton _leftMoveButton;
    private IngameButton _rightMoveButton;
    private IngameButton _jumpButton;

    private void Awake()
    {

        _gameManager = GameManager.Instance;

        Transform ingameControllerTrm = GameObject.Find("Core/Managers/UIManager/SettingCanvas/IngameController").transform;
        if(ingameControllerTrm != null)
        {

            _leftMoveButton     = FindButton(ingameControllerTrm, "Left");
            _rightMoveButton    = FindButton(ingameControllerTrm, "Right");
            _jumpButton         = FindButton(ingameControllerTrm, "Jump");

            if(_leftMoveButton != null && _rightMoveButton != null && _jumpButton != null)
            {

                Debug.Log("Add Listener");
                _leftMoveButton.OnIB_PointerDownEvent   += HandleMoveLeft;
                _rightMoveButton.OnIB_PointerDownEvent  += HandleMoveRight;

                _leftMoveButton.OnIB_PointerUpEvent     += HandleMoveStop;
                _rightMoveButton.OnIB_PointerUpEvent    += HandleMoveStop;

                _jumpButton.OnIB_PointerDownEvent       += HandleJump;

            }

        }

    }

    private void Update()
    {

        // UI Mode라면 플레이가 진행되지 않는다
        if (_gameManager.GameMode == Chf_GameMode.OnlyUI)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {

            OnTouchJumpFunc?.Invoke();

        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            OnTouchMoveXFunc?.Invoke(0);

        if (Input.GetKeyDown(KeyCode.A))
        {

            OnTouchMoveXFunc?.Invoke(-1f);

        }
        if (Input.GetKeyDown(KeyCode.D))
        {

            OnTouchMoveXFunc?.Invoke(1);

        }

    }

    private void HandleMoveLeft() => OnTouchMoveXFunc?.Invoke(-1f);
    private void HandleMoveRight() => OnTouchMoveXFunc?.Invoke(1f);
    private void HandleMoveStop() => OnTouchMoveXFunc?.Invoke(0f);
    private void HandleJump() => OnTouchJumpFunc?.Invoke();

    private IngameButton FindButton(Transform root, string name)
    {

        Transform findTrm = root.Find(name);
        if(findTrm != null)
        {

            if(findTrm.TryGetComponent(out IngameButton button))
            {

                return button;

            }

        }

        return null;

    }

}
