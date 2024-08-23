using System.Collections;
using UnityEngine;

public enum TempFSMDesignAIState
{
    Idle,
    TargetMove
}

public class TempFSM_Controller : FSM_Controller<TempFSMDesignAIState>
{
    [Header("AI Info")]
    [SerializeField]
    private Transform _target;
    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _delayTime;
    [SerializeField]
    private float _targetMoveTime;

    protected override void FSM_AISetting()
    {

        // Idle
        var idleState = new IdleState<TempFSMDesignAIState>(this);
        var idleToMoveTransition = new FSM_Transition<TempFSMDesignAIState>(this, TempFSMDesignAIState.TargetMove);
        DelayCondition delayCondition = new DelayCondition(_delayTime);
        idleToMoveTransition.AddCondition(delayCondition);

        idleState.AddTransition(idleToMoveTransition);
        AddState(TempFSMDesignAIState.Idle, idleState);

        // TargetMove
        TargetMoveStateData data = new TargetMoveStateData(_target, _speed);
        var targetMoveState = new TargetMoveState<TempFSMDesignAIState>(this, data);
        var moveToIdleTransition = new FSM_Transition<TempFSMDesignAIState>(this, TempFSMDesignAIState.Idle);
        DelayCondition targetMoveDelayCondition = new DelayCondition(_targetMoveTime);
        moveToIdleTransition.AddCondition(targetMoveDelayCondition);

        targetMoveState.AddTransition(moveToIdleTransition);
        AddState(TempFSMDesignAIState.TargetMove, targetMoveState);

    }
}
