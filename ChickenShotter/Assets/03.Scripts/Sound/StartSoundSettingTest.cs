using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSoundSettingTest : SoundPlayer
{
    [SerializeField]
    private AudioClip _bgm;
    [SerializeField]
    private AudioClip _effect;
    private void Start()
    {
        BgmStart();
    }
    public void BgmStart()
    {
        _audioSource.volume = PlayerPrefs.GetFloat("effect", 0);
        StartCoroutine(EffectTest());
    }
    IEnumerator EffectTest()
    {
        for(int i = 0; i < 3; i++)
        {
            PlayClip(_effect);
            yield return new WaitForSeconds(0.5f);
        }
        _audioSource.volume = PlayerPrefs.GetFloat("bgm", 0);
        PlayClip(_bgm);
    }
}
