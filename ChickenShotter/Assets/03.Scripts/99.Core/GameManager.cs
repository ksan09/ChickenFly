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

    // 맵 생성
    [Header("Map")]
    [SerializeField]
    private MapGenerator _mapGenerator;

    private float _createMapCycleTime = 0.25f;
    private WaitForSeconds _wfsCreateMapCycleTime;

    // 인게임 정보
    [Header("Game Info")]
    [SerializeField]
    private bool _isGamePlay = true;

    [field:SerializeField]
    public Chf_GameMode GameMode { get; private set; }
    public event Action<Chf_GameMode> OnChangeGameModeEvent;

    private int _score = 0;
    public event Action<int> OnUpdateScoreEvent;

    public int GetScore() => _score;

    private void Start()
    {

        _playerManager = PlayerManager.Instance;
        _score = 0;
        _wfsCreateMapCycleTime = new WaitForSeconds(_createMapCycleTime);

        // 맵 생성 주기 마다 점수 증가
        StartCoroutine(CreateMapCycleCo());

    }

    public void ChangeGameMode(Chf_GameMode gameMode)
    {

        GameMode = gameMode;

        switch (gameMode)
        {
            case Chf_GameMode.OnlyPlay:
                Time.timeScale = 1f;
                break;
            case Chf_GameMode.OnlyUI:
                Time.timeScale = 0;
                break;
        }

        OnChangeGameModeEvent?.Invoke(gameMode);

    }

    private IEnumerator CreateMapCycleCo()
    {

        while(_isGamePlay)
        {

            CreateMapOneStep(); // 맵 한단계 생성

            for(int i = 0; i < 8; ++i)
            {

                // 플레이어 체력 감소
                PlayerManager.Instance.GetPlayerHealth().AddHealth(-1);
                yield return _wfsCreateMapCycleTime;

            }

        }

    }

    private void CreateMapOneStep()
    {

        // 점수 추가 및 맵 생성

        _score++; // 점수 추가
        OnUpdateScoreEvent?.Invoke(_score);

        

        // 맵 생성
        _mapGenerator.Generate();

    }

}