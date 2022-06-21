using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySound : SoundPlayer
{
    [SerializeField] private AudioClip _dmged;
    // Start is called before the first frame update
    public void OnDamagedSound()
    {
        PlayClip(_dmged);
    }
}
