using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class FSM_Controller<T> : MonoBehaviour where T : Enum
{
    [SerializeField]
    private bool _useDebug = false;

    // Current State
    private T _currentState;
    private FSM_State<T> _currentStateObject = null;
    private Dictionary<T, FSM_State<T>> _stateContainer  = new Dictionary<T, FSM_State<T>>();

    protected FSM_State<T> _anyState;

    protected virtual void Awake()
    {

        _anyState = new FSM_State<T>(this);

        FSM_AISetting();

    }

    protected virtual void Start()
    {
        InitFSM_Controller();
    }

    private void LateUpdate()
    {

        if (_currentStateObject == null)
            return;

        if (_anyState != null)
        {

            _anyState.RunFSMState();

        }

        _currentStateObject.RunFSMState();

    }

    protected abstract void FSM_AISetting();
    protected virtual void Set_FSMController()
    {

        _currentState = default(T);
        _currentStateObject = _stateContainer[_currentState];

    }

    private void InitFSM_Controller()
    {

        // Set Value Child State
        if(_stateContainer.Count == 0)
        {
            enabled = false;
            Debug.LogError($"State Empty, {name}");

            return;
        }

        Set_FSMController();

    }

    // Change State
    public void ChangeState(T stateType)
    {
        if (_useDebug)
        {

            Debug.Log($"ChangeState - {stateType}");

        }

        if (_stateContainer.ContainsKey(stateType) == false)
        {
            Debug.LogWarning($"{name} has not {stateType}");
            return;
        }

        _currentStateObject.ExitFSMState();
        _currentStateObject = _stateContainer[stateType];
        _currentStateObject.EnterFSMState();

    }

    protected void AddState(T stateType, FSM_State<T> state)
    {

        _stateContainer.Add(stateType, state);

    }

}
