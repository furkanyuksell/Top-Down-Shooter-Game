using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SceneManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject gameOverMenu;
    public bool isPaused;
    public bool isOver;

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
                UnPause();
            else
                Pause();
        }    
    }

    public void Pause() // delege
    {
        Time.timeScale = 0;
        isPaused = true;
    }

    public void UnPause() // delege
    {
        Time.timeScale = 1;
        isPaused = false;
    }
    

    public void Retry()
    {

    }

    public void Quit()
    {
        Application.Quit();
    }
}
