using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CameraManager : MonoSingleton<CameraManager>
{

    private Camera _mainCam;

    [Header("VolumeList")]
    [SerializeField]
    private Volume _dizzyEffectVolume;

    public override void Init()
    {

        _mainCam = Camera.main;

    }

    public void DizzyVolumeEffect(bool realTime = false)
    {

        float start = 1f, end = 0f;
        DOTween.To(() => start, value => _dizzyEffectVolume.weight = value, end, 0.5f).SetEase(Ease.Linear).SetUpdate(realTime);

    }

}
