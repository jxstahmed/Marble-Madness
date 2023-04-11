using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointCollect : MonoBehaviour
{
    public Text ScoreText;

<<<<<<< Updated upstream
    private void Awake()
    {
        GameManager.OnGameStateChanged += subscription;
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= subscription;

    }
    private void subscription(GameState state)
    {
        if(state == GameState.pointCollect)
            score.text = "Score: " + GameManager.Instance.getScore().ToString();
=======
    // subscribe
    private void Awake()
    {
        GameManager.GameEvent += GameEventListener;
    }
>>>>>>> Stashed changes

    // unsubscribe
    private void onDestroy()
    {
        GameManager.GameEvent -= GameEventListener;
    }
    
    private void GameEventListener(GameState obj)
    {
        Debug.Log(obj);
        if(obj == GameState.CollectPoint)
        {
            ScoreText.text = "Score: " + GameManager.Instance.getScore().ToString();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

}
