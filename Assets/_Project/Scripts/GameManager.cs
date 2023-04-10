using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public GameState State;
    public static event Action<GameState> OnGameStateChanged;

    private int score;

    private int SCENE_START_MENU = 0;
    private int SCENE_PAUSE_MENU = 1;
    private int SCENE_LEVELS_1 = 2; 
    private int SCENE_LEVELS_2 = 3;
    private int DEFAULT_START_LEVEL = 1;

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
        SceneManager.LoadScene(SCENE_PAUSE_MENU, LoadSceneMode.Additive);
    }

    public void HandleGameStart()
    {
        Debug.Log("Game start, loading level 1");
        HandleChangeLevel(DEFAULT_START_LEVEL);
    }

    public async void HandleChangeLevel(int level)
    {
        Time.timeScale = 0f;

        await Task.Delay(1000);
        
        Debug.Log(SCENE_PAUSE_MENU);
        Debug.Log(SCENE_LEVELS_1);

        int scene = SCENE_LEVELS_1;

        if (level == 1) scene = SCENE_LEVELS_1;
        else if (level == 2) scene = SCENE_LEVELS_2; 

        SceneManager.LoadScene(scene);
        Time.timeScale = 1f;

    }

    public void HandleGameResuming()
    {
        SceneManager.UnloadSceneAsync(SCENE_PAUSE_MENU);
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