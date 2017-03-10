using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

    static float timeLeft = 400.0f;
    public LevelManager levelManager;


    Text text;

    void Awake()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        text.text = "" + string.Format("{0:####}", timeLeft);
        if (timeLeft < 0)
        {
           levelManager.RespawnPlayer();
           Reset();
        }
    }

    public void Reset()
    {
        timeLeft = 400.0f;
    }

    public static int TimeForScore()
    {
        int score = (int)timeLeft * 50;
        return score;
    }
}
