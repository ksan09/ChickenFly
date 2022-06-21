using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundPlayer : MonoBehaviour
{
    private AudioSource _audioSource = null;
    [SerializeField] private float _pitchRandomness = 0.2f;
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    // 피치를 이용해서 적은 리소스를 활용하는 방법
    protected void PlayerClipWithPitch(AudioClip clip)
    {
        _audioSource.Stop();
        _audioSource.clip = clip;
        _audioSource.pitch = 1f + Random.Range(-_pitchRandomness, +_pitchRandomness);
        _audioSource.Play();
    }
    protected void PlayClip(AudioClip clip)
    {
        _audioSource.Stop();
        _audioSource.clip = clip;
        _audioSource.Play();

    }

}
