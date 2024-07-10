using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{

    public event Action OnTouchFunc;

    private void Update()
    {
        
        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {

            OnTouchFunc?.Invoke();

        }

    }


}
