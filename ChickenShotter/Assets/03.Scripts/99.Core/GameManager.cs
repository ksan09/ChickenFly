using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Chf_GameMode
{

    OnlyPlay = 0,
    OnlyUI = 1

}

public class GameManager : MonoSingleton<GameManager>
{

    PlayerManager _playerManager;

    [field:SerializeField]
    public Chf_GameMode GameMode { get; private set; }
    public event Action<Chf_GameMode> OnChangeGameModeEvent;

    private void Start()
    {

        _playerManager = PlayerManager.Instance;

    }

    public void ChangeGameMode(Chf_GameMode gameMode)
    {

        GameMode = gameMode;
        OnChangeGameModeEvent?.Invoke(gameMode);

    }


}