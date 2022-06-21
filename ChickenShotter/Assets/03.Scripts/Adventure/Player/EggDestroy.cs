using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggDestroy : PoolableMono
{
    public override void Reset()
    {
        //
    }

    private void Update()
    {
        StartCoroutine("Delay");
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.4f);
        PoolManager.Instance.Push(this);
    }
}
