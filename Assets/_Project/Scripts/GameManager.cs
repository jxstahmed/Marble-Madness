using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public GameState State;
    public static event Action<GameState> OnGameStateChanged;

    private int score;

    private int SCENE_START_MENU = 0;
    private int SCENE_LEVEL_1 = 1; 
    private int SCENE_LEVEL_2 = 2;

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
            case GameState.GameStart:
                HandleGameStart();
                break;
            case GameState.GameFinished:
                HandleGameFinished();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnGameStateChanged?.Invoke(newState);
    }

    public void HandleStartMenu()
    {
        SceneManager.LoadScene(SCENE_START_MENU);
    }

    public void HandlePauseMenu()
    {
        Time.timeScale = 0f;
    }

    public void HandleGameStart()
    {
        SceneManager.LoadScene(SCENE_LEVEL_1);
    }

    public void HandleChangeLevel(int level)
    {
        int scene = SCENE_LEVEL_1;

        if (level == 0) scene = SCENE_LEVEL_1;
        else if (level == 1) scene = SCENE_LEVEL_2; 

        SceneManager.LoadScene(scene);
    }

    public void HandleGameResuming()
    {
        Time.timeScale = 1f;
    }

    public void HandleGameFinished()
    {

    }

    public void HandleExit()
    {
        Application.Quit();
    }

    public void CollectPoint(int value)
    {
        score += value;
    }
}

public enum GameState
{
    StartMenu,
    PauseMenu,
    GameStart,
    GameResuming,
    GameFinished
}