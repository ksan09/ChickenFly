using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM_NameIsType : MonoBehaviour
{
    // Set State Name
    protected virtual void OnValidate()
    {
        name = this.GetType().Name;
    }
}
