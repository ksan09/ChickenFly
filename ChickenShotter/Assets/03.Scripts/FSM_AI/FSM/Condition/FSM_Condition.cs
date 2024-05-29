using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FSM_Condition
{
    public FSM_Condition() { }

    public abstract void ResetCondition();
    public abstract bool Check_FSMCondition();

}
