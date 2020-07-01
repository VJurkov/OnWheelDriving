using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTimer : MonoBehaviour
{
    public LevelTimer levelTimer;
    private void OnEnable()
    {
        levelTimer.isPaused = false;
    }
}
