using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class MenuManager : MonoBehaviour
{

    private int SCENE_START_MENU = 0;
    private int SCENE_LEVELS_1 = 1;
    private int SCENE_LEVELS_2 = 2;
    private int SCENE_FINISH = 3;


    private bool isPaused = false;
    private bool isChangingLevel = false;

    private int DEFAULT_START_LEVEL = 1;
    private int DEFAULT_RESTART_LEVEL = 1;

    public GameObject PauseMenu;

    private void Awake()
    {
        GameManager.GameEvent += onGameEventListen;
    }

    // unsubscribe
    private void OnDestroy()
    {
        GameManager.GameEvent -= onGameEventListen;

    }

    private void onGameEventListen(GameState state)
    {
        if (state == GameState.StartLevel1)
        {
            HandleChangeLevel(1);
        }
        else if (state == GameState.StartLevel2)
        {
            HandleChangeLevel(2);
        }
        else if (state == GameState.GameFinished)
        {
            HandleGameFinished();
        }
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
            // Show the menuG
            if(PauseMenu != null)
            {
                PauseMenu.SetActive(true);
            }
        }
    }


    public void HandleGameResuming()
    {
        if (isPaused)
        {
            if (PauseMenu != null)
            {
                // Hide the menu
                PauseMenu.SetActive(false);

                // Resume the game
                Time.timeScale = 1f;

                // Adjust the boolean
                isPaused = false;
            }

        }
    }

    public void HandleGameStart()
    {
        GameManager.Instance.SetScore(0);
        HandleChangeLevel(DEFAULT_START_LEVEL);
    }


    public void HandleGameRestart()
    {
        GameManager.Instance.SetScore(0);
        HandleChangeLevel(DEFAULT_RESTART_LEVEL);
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
        
        // useful for restart level
        DEFAULT_RESTART_LEVEL = scene;

        SceneManager.LoadScene(scene);
        GameManager.Instance.SetScore(0);

        // Resume the game
        Time.timeScale = 1f;

        // Adjust the boolean
        isChangingLevel = false;
    }


    public void HandleGameFinished()
    {
        Task.Delay(1000);
        SceneManager.LoadScene(SCENE_FINISH);
    }

    public void HandleExit()
    {
        Application.Quit();
    }

}
