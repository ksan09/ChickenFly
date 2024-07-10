using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoSingleton<TimeManager>
{

    Coroutine _setTimeShortTimeCoroutine = null;


    public void SetTime(float timeScale)
    {

        Time.timeScale = timeScale;

    }

    public void SetTimeShortTime(float timeScale, float time)
    {

        if(_setTimeShortTimeCoroutine != null)
        {

            StopCoroutine(_setTimeShortTimeCoroutine);

        }

        _setTimeShortTimeCoroutine = StartCoroutine(SetTimeShortTimeCo(timeScale, time));

    }

    IEnumerator SetTimeShortTimeCo(float timeScale, float time)
    {

        Time.timeScale = timeScale;
        yield return new WaitForSecondsRealtime(time);
        Time.timeScale = 1f;

        _setTimeShortTimeCoroutine = null;

    }




}
