using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : SoundPlayer
{
    [SerializeField] private AudioClip _jumpSound;
    [SerializeField] private AudioClip _damagedSound;
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
