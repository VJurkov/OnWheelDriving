using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseTrigger : MonoBehaviour
{

    public GameObject losePanel;

    public void ShowLose()
    {
        Time.timeScale = 0f;
        AudioListener.volume = 0f;
        losePanel.SetActive(true);
    } 
}
