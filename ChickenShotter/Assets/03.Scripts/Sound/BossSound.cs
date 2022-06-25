using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSound : SoundPlayer
{
    [SerializeField] private AudioClip _dmged;
    [SerializeField] private AudioClip _dieSound;
    private bool _dead = false;
    private void Start()
    {

        _audioSource.volume = PlayerPrefs.GetFloat("effect", 0);
    }
    // Start is called before the first frame update
    public void OnDamagedSound()
    {
        if(_dead == false)
        {
            PlayClip(_dmged);
        }
    }
    public void OnDieSound()
    {
        PlayClip(_dieSound);
        _dead = true;
    }
}
