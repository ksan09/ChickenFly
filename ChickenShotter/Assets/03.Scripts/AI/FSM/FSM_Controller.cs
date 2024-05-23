using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM_Controller : MonoBehaviour
{
    // Current State
    private FSM_State _currentState = null;
    private Dictionary<string, FSM_State> _stateContainer;

    private void Awake()
    {

        // Init Value
        InitFSM_Controller();

    }

    private void LateUpdate()
    {

        if (_currentState == null)
            return;

        _currentState.RunFSMState();

    }

    private void InitFSM_Controller()
    {
        _stateContainer = new Dictionary<string, FSM_State>();

        // Set Value Child State
        for (int i = 0; i < transform.childCount; i++)
        {

            if (TryGetComponent<FSM_State>(out FSM_State childState))
            {

                childState.SetOwner(this);
                _stateContainer.Add(childState.name, childState);
            }

        }

        if(_stateContainer.Count == 0)
        {
            enabled = false;
            Debug.LogError($"State Empty, {name}");
        }    
    }

    // Change State
    public void ChangeState(string stateObjectName)
    {

        if (_stateContainer.ContainsKey(stateObjectName) == false)
        {
            Debug.LogWarning($"{name} has not {stateObjectName}");
            return;
        }

        _currentState.ExitFSMState();
        _currentState = _stateContainer[stateObjectName];
        _currentState.EnterFSMState();

    }
    public void ChangeState(FSM_State stateObject)
    {
        ChangeState(stateObject.name);
    }


}
