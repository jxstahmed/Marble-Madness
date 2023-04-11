using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    private GameState State;
    public static event Action<GameState> GameEvent;
    public AudioSource pointCollectSound;

    private int Score = 0;

    private int SCENE_START_MENU = 0;
    private int SCENE_LEVELS_1 = 1; 
    private int SCENE_LEVELS_2 = 2;

    public GameObject PauseMenu;

    private bool isPaused = false;
    private bool isChangingLevel = false;

    public int getScore()
    {
        return Score;
    }

    private int DEFAULT_START_LEVEL = 1;
    private int _current_level = 1;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public void HandlePointCollect(int value)
    {
        Score += value;
        if(pointCollectSound != null)
        {
            pointCollectSound.Play();
        }
        
        emitGameEvent(GameState.CollectPoint);
    }

    public void HandleStartMenu()
    {
        SceneManager.LoadScene(SCENE_START_MENU);

    }

    public void HandlePauseMenu()
    {
  
        if (PauseMenu != null)
        {
            // Adjust the boolean
            isPaused = true;
            // Pause the time
            Time.timeScale = 0f;
            // Show the menu
            showPauseMenu();
        }
    }

    private void showPauseMenu()
    {
        PauseMenu.SetActive(true);
        foreach(Transform transform in PauseMenu.transform)
        {
            transform.gameObject.SetActive(true);
        }
    }

    private void hidePauseMenu()
    {
        PauseMenu.SetActive(false);
        foreach (Transform transform in PauseMenu.transform)
        {
            transform.gameObject.SetActive(false);
        }
    }

    public void HandleGameResuming()
    {
        if(isPaused)
        {
            if(PauseMenu != null)
            {
                // Hide the menu
                hidePauseMenu();

                // Resume the game
                Time.timeScale = 1f;

                // Adjust the boolean
                isPaused = false;
            }

        }
    }

    public void HandleGameStart()
    {
        HandleChangeLevel(DEFAULT_START_LEVEL);
    }

    public async void HandleChangeLevel(int level)
    {
        // Avoid duplicated loading of levels
        if (isChangingLevel) return;

        // Adjust the boolean
        isChangingLevel = true;

        // Pause the game
        Time.timeScale = 0f;

        // Delay, no idea why, ask the person who wrote this
        await Task.Delay(1000);
        
        // Default scene
        int scene = SCENE_LEVELS_1;

        if (level == 1) scene = SCENE_LEVELS_1;
        else if (level == 2) scene = SCENE_LEVELS_2; 

        SceneManager.LoadScene(scene);

        // Resume the game
        Time.timeScale = 1f;

        // Adjust the boolean
        isChangingLevel = false;
        _current_level = scene;
    }


    public void HandleGameFinished()
    {

    }

    public void HandleGameRestart()
    {
        Score = 0;
        HandleChangeLevel(_current_level);
    }

    public void HandleExit()
    {
        Application.Quit();
    }

    public void emitGameEvent(GameState newState)
    {

        switch (newState)
        {
            case GameState.StartMenu:
            case GameState.PauseMenu:
            case GameState.GameResuming:
            case GameState.GameStart:
            case GameState.GameRestart:
            case GameState.GameFinished:
            case GameState.CollectPoint:
                State = newState;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        GameEvent?.Invoke(newState);
    }
}



public enum GameState
{
    StartMenu,
    PauseMenu,
    GameStart,
    GameResuming,
    GameRestart,
    GameFinished,
    CollectPoint
}