using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryScenBgm : SoundPlayer
{
    [SerializeField] private AudioClip bgm;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource.volume = PlayerPrefs.GetFloat("bgm", 0);
        PlayClip(bgm);
    }

    
}
