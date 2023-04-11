using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource pointCollectSound;
    public AudioSource backgroundMusic;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            GameManager.GameEvent += onGameEventListen;

            if (backgroundMusic != null)
            {
                backgroundMusic.Play();
            }
        } else
        {
            Destroy(gameObject);
        }
    }

    // unsubscribe
    private void OnDestroy()
    {
        Debug.Log("OnDestroy");
        GameManager.GameEvent -= onGameEventListen;

        if(backgroundMusic != null) {
            
            backgroundMusic.Stop(); 
        }

    }

    private void onGameEventListen(GameState state)
    {
        if (state == GameState.CollectPoint)
        {
            playCollectPointSound();
        }
    }

    private void playCollectPointSound()
    {
        if (pointCollectSound != null)
        {
            pointCollectSound.Play();
        }
    }
}
