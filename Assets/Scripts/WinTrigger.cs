using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinTrigger : MonoBehaviour
{

    public bool endGame=false;
    public GameObject winPanel;

    public GameObject health;
    public GameObject timer;

    private void OnTriggerEnter(Collider other)
    {
        if(endGame)
        {
            Time.timeScale = 0f;
            AudioListener.volume = 0f;
            winPanel.SetActive(true);
            health.SetActive(false);
            timer.SetActive(false);
        }
        else
        {
            SceneManager.LoadScene("LevelTwo");
        }
    }
}
