using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Danger : PoolableMono
{
    [SerializeField] private string dangerPrefab;
    private SpriteRenderer danger;
    private float FadeTime = 0.1f;
    private float dangerSpawnTime = 2f;
    private float crtTime = 0;
    private bool doCoroutine = false;
    // Start is called before the first frame update
    private void Start()
    {
        danger = GetComponent<SpriteRenderer>();
        
    }
    private void Update()
    {
        if(doCoroutine == false)
        {
            StartCoroutine("TwinkleLoop");
            doCoroutine = true;
        }
        crtTime += Time.deltaTime;
        if (crtTime > dangerSpawnTime)
        {
            crtTime = 0;
            StopCoroutine("TwinkleLoop");
            doCoroutine = false;
            Enemy mFast = PoolManager.Instance.Pop(dangerPrefab) as Enemy;
            mFast.transform.position = new Vector3(6f, transform.position.y, 0);
            
            PoolManager.Instance.Push(this);
            
        }
    }

    IEnumerator TwinkleLoop()
    {
        while (true)
        {
            yield return StartCoroutine(FadeEffect(1, 0));
            yield return StartCoroutine(FadeEffect(0, 1));
        }
    }
    IEnumerator FadeEffect(float start, float end)
    {
        float currentTime = 0;
        float percent = 0;
        while (percent < 1)
        {
            Debug.Log(percent);
            currentTime += Time.deltaTime;
            percent = currentTime / FadeTime;

            Color color = danger.color;
            color.a = Mathf.Lerp(start, end, percent);
            danger.color = color;

            yield return null;
        }
    }

    public override void Reset()
    {
        //
    }
}
