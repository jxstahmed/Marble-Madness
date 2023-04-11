using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public GameState State;
    public static event Action<GameState> OnGameStateChanged;
    public AudioSource pointCollectSound;

    private int score = 0;

    private int SCENE_START_MENU = 0;
    private int SCENE_LEVELS_1 = 1; 
    private int SCENE_LEVELS_2 = 2;

<<<<<<< Updated upstream
=======
    private bool isLoadingLevel = false;
    private bool isGamePaused = false;

    private GameState CurrentGameState;
    public static event Action<GameState> GameEvent;

    public GameObject PauseMenu;

>>>>>>> Stashed changes
    public int getScore()
    {
        return score;
    }

    private int DEFAULT_START_LEVEL = 1;

    void Awake()
    {
<<<<<<< Updated upstream
        Instance = this;
        DontDestroyOnLoad(this);
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
            case GameState.pointCollect:
                HandlePointCollect();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnGameStateChanged?.Invoke(newState);
    }

    private void HandlePointCollect()
    {
        score += 1;
        pointCollectSound.Play();
=======
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
>>>>>>> Stashed changes
    }

    public void HandleStartMenu()
    {
        SceneManager.LoadScene(SCENE_START_MENU);

    }

    public void HandlePauseMenu()
    {
        Time.timeScale = 0f;
<<<<<<< Updated upstream
        SceneManager.LoadScene(SCENE_PAUSE_MENU, LoadSceneMode.Additive);
=======
        if (PauseMenu != null)
        {
            PauseMenu.SetActive(true);
        }
>>>>>>> Stashed changes
    }

    public void HandleGameStart()
    {
<<<<<<< Updated upstream
        Debug.Log("Game start, loading level 1");
=======
>>>>>>> Stashed changes
        HandleChangeLevel(DEFAULT_START_LEVEL);
    }

    public async void HandleChangeLevel(int level)
    {
<<<<<<< Updated upstream
=======
        // Avoid duplicate loading
        if (isLoadingLevel) return;
        // Update the boolean
        isLoadingLevel = true;

        // Pause the time
>>>>>>> Stashed changes
        Time.timeScale = 0f;

        await Task.Delay(1000);
        
        Debug.Log(SCENE_PAUSE_MENU);
        Debug.Log(SCENE_LEVELS_1);

        int scene = SCENE_LEVELS_1;

        if (level == 1) scene = SCENE_LEVELS_1;
        else if (level == 2) scene = SCENE_LEVELS_2; 

<<<<<<< Updated upstream
=======
        // Load the scene
>>>>>>> Stashed changes
        SceneManager.LoadScene(scene);
        Time.timeScale = 1f;

        // Update the boolean
        isLoadingLevel = false;
    }

    public void HandleGameResuming()
    {
<<<<<<< Updated upstream
        SceneManager.UnloadSceneAsync(SCENE_PAUSE_MENU);
        Time.timeScale = 1f;
=======
        if(isGamePaused)
        {
            // Update the boolean
            isGamePaused = false;

            if (PauseMenu != null)
            {
                PauseMenu.SetActive(false);
            }
            // We resume the time
            Time.timeScale = 1f;
        }
>>>>>>> Stashed changes
    }

    public void HandleGameFinished()
    {

    }

    public void HandleExit()
    {
        Application.Quit();
    }

<<<<<<< Updated upstream
    public void CollectPoint(int value)
=======

    public void HandlePointCollect(int value)
>>>>>>> Stashed changes
    {
        score += value;
        //pointCollectSound.Play();
        // update any components that are listening to this event
        emitGameState(GameState.CollectPoint);
    }
<<<<<<< Updated upstream
=======


    public void emitGameState(GameState newState)
    {
        switch (newState)
        {
            case GameState.StartMenu:
            case GameState.PauseMenu:
            case GameState.GameResumed:
            case GameState.GamePaused:
            case GameState.GameFinished:
            case GameState.GameExiting:
            case GameState.CollectPoint:
                CurrentGameState = newState;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        GameEvent?.Invoke(newState);
    }
>>>>>>> Stashed changes
}

public enum GameState
{
    StartMenu,
    PauseMenu,
<<<<<<< Updated upstream
    GameStart,
    GameResuming,
    GameFinished,
    pointCollect
=======
    GameResumed,
    GamePaused,
    GameFinished,
    GameExiting,
    CollectPoint,
>>>>>>> Stashed changes
}