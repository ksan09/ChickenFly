using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using System;

public enum SoundType
{

    Master,
    BGM,
    SFX,


}

public class SoundManager : MonoSingleton<SoundManager>
{

    [Header("Info")]
    [SerializeField]
    private AudioMixerContainerSO _audioMixerContainerSO;
    [SerializeField]
    private AudioClipContainerSO _audioClipContainerSO;

    private AudioMixer _audioMixer;
    
    private Dictionary<SoundType, string> _soundTypeNameDictionary;
    private Dictionary<SoundType, AudioMixerGroup> _soundTypeAudioMixerGroupDictionary;
    private Dictionary<string, AudioClip> _audioClipByNameDictionary;

    public override void Init()
    {

        _audioMixer = _audioMixerContainerSO.AudioMixers.MainMixer;

        _soundTypeNameDictionary = new Dictionary<SoundType, string>()
        {
            { SoundType.Master,     "Master"    },
            { SoundType.BGM,        "BGM"       },
            { SoundType.SFX,        "SFX"       },

        };

        _soundTypeAudioMixerGroupDictionary = new Dictionary<SoundType, AudioMixerGroup>()
        {
            { SoundType.Master,     _audioMixerContainerSO.AudioMixers.MasterMixer      },
            { SoundType.BGM,        _audioMixerContainerSO.AudioMixers.BGMMixer         },
            { SoundType.SFX,        _audioMixerContainerSO.AudioMixers.SFXMixer         },
        };

        _audioClipByNameDictionary = new Dictionary<string, AudioClip>();
        foreach(var clip in _audioClipContainerSO.AudioClips)
        {
            if(_audioClipByNameDictionary.ContainsKey(clip.name))
            {

                int num = 2;
                while(_audioClipByNameDictionary.ContainsKey($"{clip.name}{num}"))
                {
                    num++;
                }

                _audioClipByNameDictionary.Add($"{clip.name}{num}", clip);

            }
            else
            {

                _audioClipByNameDictionary.Add(clip.name, clip);

            }


        }

    }

    public void SetSound(SoundType type, float volume)
    {

        if(_soundTypeNameDictionary.ContainsKey(type))
        {

            _audioMixer.SetFloat(_soundTypeNameDictionary[type], volume);

        }
        else
        {

            Debug.LogError($"SoundType: {type} is no name");

        }

        
    }

    public void PlaySound(string soundName, float volume = 0.5f, SoundType type = SoundType.SFX)
    {

        if (_audioClipByNameDictionary.ContainsKey(soundName) == false
            || _soundTypeAudioMixerGroupDictionary.ContainsKey(type) == false)
            return;

        PoolableMono poolableMono = PoolManager.Instance.Pop(soundName);

        if(poolableMono is PoolingSound)
        {

            PoolingSound poolingSound = poolableMono as PoolingSound;
            poolingSound.PlaySound(_audioClipByNameDictionary[soundName], volume, _soundTypeAudioMixerGroupDictionary[type]);

        }
        else
        {

            PoolManager.Instance.Push(poolableMono);
            Debug.LogError($"{soundName} is not pooling sound");

        }

    }

}
