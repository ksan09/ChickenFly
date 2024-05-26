using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayCondition : FSM_Condition
{
    private float _currentTime;

    [SerializeField]
    private float _delayTime;


    public override bool Check_FSMCondition()
    {
        if (_currentTime >= _delayTime)
            return true;

        _currentTime += Time.deltaTime;
        return false;
    }

    public override void ResetCondition()
    {
        _currentTime = 0;
    }

}
