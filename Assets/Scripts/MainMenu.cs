using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("LevelOne", LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        //Debug.Log("quit game");
        Application.Quit();
    }
}
