using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSound : SoundPlayer
{
    [SerializeField] private AudioClip _bgm;
    private void Start()
    {
        _audioSource.volume = PlayerPrefs.GetFloat("bgm", 0);
        PlayClip(_bgm);
    }


}
