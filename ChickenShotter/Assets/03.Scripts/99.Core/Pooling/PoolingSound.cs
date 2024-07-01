using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class PoolingSound : PoolableMono
{

    [Header("Info")]
    private AudioSource _audioSource;
    private WaitUntil _waitUntilStopAudioSource;

    private Coroutine _playSoundCoroutine;

    private void Awake()
    {

        _audioSource = GetComponent<AudioSource>();
        _waitUntilStopAudioSource = new WaitUntil(() => { return !_audioSource.isPlaying; });

    }

    public void PlaySound(AudioClip clip, float volume, AudioMixerGroup mixer)
    {

        _audioSource.clip = clip;
        _audioSource.volume = volume;
        _audioSource.outputAudioMixerGroup = mixer;

        _playSoundCoroutine = StartCoroutine(PlaySoundCo(1));

    }
    public void PlaySound(AudioClip clip, float volume, AudioMixerGroup mixer, bool loop = false, float pitch = 1, float stereoPen = 0, float spatialBlend = 0, float reverbZoneMix = 1)
    {

        _audioSource.clip = clip;
        _audioSource.volume = volume;
        _audioSource.outputAudioMixerGroup = mixer;

        _audioSource.loop = loop;
        _audioSource.pitch = pitch;
        _audioSource.panStereo = stereoPen;

        _audioSource.spatialBlend = spatialBlend;
        _audioSource.reverbZoneMix = reverbZoneMix;

        _playSoundCoroutine = StartCoroutine(PlaySoundCo(1));

    }

    public void Stop()
    {

        _audioSource.Stop();
        StopCoroutine(_playSoundCoroutine);

    }

    IEnumerator PlaySoundCo(int playCount)
    {

        for(int i = 0; i < playCount; i++)
        {

            _audioSource.Play();
            yield return _waitUntilStopAudioSource;

            _audioSource.Stop();

        }

        PoolManager.Instance.Push(this);


    }

    public override void Reset()
    {
        
    }

}
