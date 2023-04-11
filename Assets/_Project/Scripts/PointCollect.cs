using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PointCollect : MonoBehaviour
{
    public TMP_Text ScoreText;

    // subscribe
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
        if(state == GameState.CollectPoint)
        {
            ScoreText.text = "Score: " + GameManager.Instance.getScore().ToString();
        }
    }
}
