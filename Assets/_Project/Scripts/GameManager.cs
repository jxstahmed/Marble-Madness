using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public GameState State;
    public static event Action<GameState> OnGameStateChanged;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateGameState(GameState.StartMenu);
    }

    void Update()
    {

    }
    
    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch (newState)
        {
            case GameState.StartMenu:
                HandleStartMenu();
                break;
            case GameState.PauseMenu:
                HandlePauseMenu();
                break;
            case GameState.GameResuming:
                HandleGameResuming();
                break;
            case GameState.GameFinished:
                HandleGameFinished();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnGameStateChanged?.Invoke(newState);
    }

    private void HandleStartMenu()
    {

    }

    private void HandlePauseMenu()
    {

    }

    private void HandleGameResuming()
    {

    }

    private void HandleGameFinished()
    {

    }
}

public enum GameState
{
    StartMenu,
    PauseMenu,
    GameResuming,
    GameFinished
}