using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public struct AudioMixerContainer
{

    public AudioMixer MainMixer;
    public AudioMixerGroup MasterMixer;
    public AudioMixerGroup BGMMixer;
    public AudioMixerGroup SFXMixer;

}

[CreateAssetMenu(fileName = "AudioMixerContainer",menuName = "SO/Sound/AudioMixerContainer")]
public class AudioMixerContainerSO : ScriptableObject
{

    public AudioMixerContainer AudioMixers;

}
