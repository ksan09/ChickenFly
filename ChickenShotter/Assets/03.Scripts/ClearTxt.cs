using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class ClearTxt : SoundPlayer
{
    [SerializeField] private TextMeshProUGUI endTxt;
    [SerializeField] private AudioClip endingBgm;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource.volume = PlayerPrefs.GetFloat("bgm", 0);
        if(_audioSource.volume != 0)
            _audioSource.volume += 0.2f;

        PlayClip(endingBgm);
        endTxt.text = $"Score : {PlayerManager.Instance.Money}\n\nProgramming : KangSan\nArt : KangSan\nSound :\n8 - bit 8Pack\n8BIT MUSIC ALBUM - 051321\nGame Sound Solutions - 8 bits Elements\n\nThanks For Playing!";
        StartCoroutine(StartScene());
    }

    IEnumerator StartScene()
    {
        yield return new WaitForSeconds(1f);
        transform.DOMoveY(1500, 20);
    }
}
