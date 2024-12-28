using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool gameIsPaused = false;
    public GameObject PauseMenuUI;
    

    private void Update()
    {
        if (!gameIsPaused) Resume();
        else Pause();
    }

    private void Resume()
    {
        PauseMenuUI.SetActive(false);
        gameIsPaused = false;
    }

    private void Pause()
    {
        PauseMenuUI.SetActive(true);
        gameIsPaused = true;
    }
    
    
    public void PauseGameButton()
    {
        gameIsPaused = true;
    }

    public void ResumeGameButton()
    {
        gameIsPaused = false;
    }

    public void QuitGameButton()
    {
        SceneManager.LoadScene("Main Game");
        gameIsPaused = false;
    }
}
