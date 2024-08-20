using Cinemachine;
using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CameraManager : MonoSingleton<CameraManager>
{

    private Camera _mainCam;
    [Header("VCam")]
    [SerializeField] private CinemachineVirtualCamera _vPlayerCam;

    // Shake Value
    private CinemachineBasicMultiChannelPerlin _multiChannelPerlin;
    private WaitForSeconds _wfsShakeTime;
    private Coroutine _shakeCoroutine;

    [Header("VolumeList")]
    [SerializeField] private Volume _dizzyEffectVolume;

    public override void Init()
    {

        _mainCam = Camera.main;

        _multiChannelPerlin = _vPlayerCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _wfsShakeTime = new WaitForSeconds(0.1f);

    }

    public void DizzyVolumeEffect(bool realTime = false)
    {

        float start = 1f, end = 0f;
        DOTween.To(() => start, value => _dizzyEffectVolume.weight = value, end, 0.5f).SetEase(Ease.Linear).SetUpdate(realTime);

    }

    public void ShakeCam(float amplitudeGain, float frequencyGain)
    {

        if (_shakeCoroutine != null)
            StopCoroutine(_shakeCoroutine);

        _shakeCoroutine = StartCoroutine(ShakeCamCo(amplitudeGain, frequencyGain));

    }

    private IEnumerator ShakeCamCo(float amplitudeGain, float frequencyGain)
    {

        _multiChannelPerlin.m_AmplitudeGain = amplitudeGain;
        _multiChannelPerlin.m_FrequencyGain = frequencyGain;

        yield return _wfsShakeTime;

        _multiChannelPerlin.m_AmplitudeGain = 0f;
        _multiChannelPerlin.m_FrequencyGain = 0f;
        _shakeCoroutine = null;

    }



}
