using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

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
    private AudioMixer _audioMixer;

    private Dictionary<SoundType, string> _soundTypeNameDictionary;
    private Dictionary<SoundType, AudioMixerGroup> _soundTypeAudioMixerGroupDictionary;

    public override void Init()
    {

        _soundTypeNameDictionary = new Dictionary<SoundType, string>()
        {
            { SoundType.Master,     "Master"    },
            { SoundType.BGM,        "BGM"       },
            { SoundType.SFX,        "SFX"       },

        };

        
        //_soundTypeAudioMixerGroupDictionary = new Dictionary<SoundType, AudioMixerGroup>()
        //{
        //    { SoundType.Master,         },
        //    { SoundType.BGM,            },
        //    { SoundType.SFX,            },
        //
        //};

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

        PoolableMono poolableMono = PoolManager.Instance.Pop(soundName);

        if(poolableMono is PoolingSound)
        {

            PoolingSound poolingSound = poolableMono as PoolingSound;
            //poolingSound.PlaySound(null, volume, )

        }
        else
        {

            PoolManager.Instance.Push(poolableMono);
            Debug.LogError($"{soundName} is not pooling sound");

        }
        


    }

}
