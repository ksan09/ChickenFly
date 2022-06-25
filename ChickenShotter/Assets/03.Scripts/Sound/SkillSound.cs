using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSound : SoundPlayer
{
    [SerializeField] private AudioClip _laserSound;
    [SerializeField] private AudioClip _shotGunSound;
    [SerializeField] private AudioClip _homingBullet;
    [SerializeField] private AudioClip _machinegunSound;
    private void Start()
    {
        _audioSource.volume = PlayerPrefs.GetFloat("effect", 0);
    }
    // Start is called before the first frame update
    public void LaserSound()
    {
        PlayClip(_laserSound);
    }
    public void ShotGunSound()
    {
        PlayClip(_shotGunSound);
    }
    public void HomingBulletSound()
    {
        PlayClip(_homingBullet);
    }
    public void MachinegunSound()
    {
        PlayerClipWithPitch(_machinegunSound);
    }
}
