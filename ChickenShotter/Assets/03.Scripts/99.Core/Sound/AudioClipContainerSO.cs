using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "AudioClipContainer", menuName = "SO/Sound/AudioClipContainer")]
public class AudioClipContainerSO : ScriptableObject
{

    public List<AudioClip> AudioClips;


}
