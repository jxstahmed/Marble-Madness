using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointCollect : MonoBehaviour
{
    [SerializeField] public int points = 0;
    public Text score;

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
