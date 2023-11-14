using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenu;
    AudioManager audioManager;

    public static bool paused = false;

    PauseAction action;

    private void Awake()
    {
        action = new PauseAction();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnEnable()
    {
        action.Enable();
    }

    private void OnDisable()
    {
        action.Disable();
    }

    private void Start()
    {
        action.Pause.PauseGame.performed += _ => DeterminePause();
        audioManager.PlayMusic(audioManager.PauseMenu);
    }

    private void DeterminePause()
    {
        if (paused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }
    public void PauseGame()
    {
        audioManager.PlaySFX(audioManager.click);
        Time.timeScale = 0;
        //AudioListener.pause = true;
        paused = true;
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        audioManager.PlaySFX(audioManager.click);
        Time.timeScale = 1;
        //AudioListener.pause = false;
        paused = false;
        pauseMenu.SetActive(false);
    }

    public void MainMenu()
    {
        audioManager.PlaySFX(audioManager.click);
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        audioManager.PlaySFX(audioManager.click);
        Application.Quit();
        Debug.Log("Quitting");
    }
}
