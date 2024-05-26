using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FSM_Condition : FSM_NameIsType
{
    protected FSM_Controller _owner;


    public abstract void ResetCondition();
    public abstract bool Check_FSMCondition();
    public void SetOwner(FSM_Controller owner)
    {
        _owner = owner;
    }
}
