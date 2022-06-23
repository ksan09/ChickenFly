using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : SoundPlayer
{
    [SerializeField] private AudioClip _jumpSound;
    [SerializeField] private AudioClip _damagedSound;
    private void Start()
    {
        _audioSource.volume = PlayerPrefs.GetFloat("effect", 0);
    }
    // Start is called before the first frame update
    public void JumpSound()
    {
        PlayerClipWithPitch(_jumpSound);
    }
    public void DamagedSound()
    {
        PlayerClipWithPitch(_damagedSound);
    }
}
