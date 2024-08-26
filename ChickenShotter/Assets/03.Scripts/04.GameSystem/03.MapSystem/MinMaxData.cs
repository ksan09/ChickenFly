using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MinMaxData<T> where T : IComparable<T>
{

    public T Min;
    public T Max;

}
