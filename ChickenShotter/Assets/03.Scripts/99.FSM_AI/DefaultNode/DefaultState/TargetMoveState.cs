using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct TargetMoveStateData
{

    public TargetMoveStateData(Transform target, float moveSpeed)
    {
        Target = target;
        MoveSpeed = moveSpeed;
    }

    public Transform Target;
    public float MoveSpeed;

}

public class TargetMoveState<T> : FSM_State<T> where T : Enum
{
    private Transform _transform;
    private Transform _target;

    private Vector3 _targetPosition;

    private Vector3 _dir;
    private float _speed;

    public TargetMoveState(FSM_Controller<T> owner, TargetMoveStateData data) : base(owner)
    {

        _transform = owner.transform;
        _target = data.Target;
        _speed = data.MoveSpeed;

    }

    protected override void EnterState()
    {
        
        _targetPosition = _target.position;
        _dir = (_targetPosition - _transform.position).normalized;

    }

    protected override void ExitState()
    {
        
    }

    protected override void UpdateState()
    {

        _transform.position += _dir * _speed * Time.deltaTime;

        if(Vector3.Distance(_targetPosition, _transform.position) < 0.2f)
        {
            _targetPosition = _target.position;
            _dir = (_targetPosition - _transform.position).normalized;
        }

    }
}
