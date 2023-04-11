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

    public int DEFAULT_RESTART_LEVEL = 1;
    private int Score = 0;


    public int getScore()
    {
        return Score;
    }

    public void SetScore(int score)
    {
        Score = score;
    }

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }

    public void HandlePointCollect(int value)
    {
        Score += value;
        emitGameEvent(GameState.CollectPoint);
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
            case GameState.StartLevel1:
            case GameState.StartLevel2:
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
    CollectPoint,
    StartLevel1,
    StartLevel2
}