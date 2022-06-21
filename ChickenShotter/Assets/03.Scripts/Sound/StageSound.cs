using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSound : SoundPlayer
{
    [SerializeField] private AudioClip _bgm;

    private void Start()
    {
        PlayClip(_bgm);
    }


}
