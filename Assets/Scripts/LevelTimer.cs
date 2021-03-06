﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour
{
    private float currentTime = 0f;
    private float startingTime = 100f;

    public bool isPaused = true;

    public Player player;

    public LoseTrigger trigger;

    [SerializeField] Text countdownText;

    void Start()
    {
        currentTime = startingTime;
    }

    void Update()
    {
        if(isPaused)
        {
            return;
        }
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");
        player.TakeDamge(0.1f * Time.deltaTime);
        if (currentTime < 5)
        {
            countdownText.color = Color.red;
        }

        if(currentTime <=0)
        {
            currentTime = 0;
            isPaused = true;
            Time.timeScale = 0f;
            trigger.ShowLose();
        }
    }
}
