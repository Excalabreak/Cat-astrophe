using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject setting;

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
        Time.timeScale = 0;
        audioManager.PlaySFX(audioManager.click);
        AudioListener.pause = true;
        paused = true;
        pauseMenu.SetActive(true);
        CursorManager.Instance.ShowCursor();
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        audioManager.PlaySFX(audioManager.click);
        AudioListener.pause = false;
        paused = false;
        pauseMenu.SetActive(false);
        CursorManager.Instance.HideCursor();
    }

    public void MainMenu()
    {
        audioManager.PlaySFX(audioManager.click);
        SceneManager.LoadScene(0);
        CursorManager.Instance.ShowCursor();
    }

    public void QuitGame()
    {
        audioManager.PlaySFX(audioManager.click);
        Application.Quit();
        Debug.Log("Quitting");
    }

    public void OpenSetting()
    {
        audioManager.PlaySFX(audioManager.click);
        setting.SetActive(true);
    } 
    
    public void CloseSetting()
    {
        audioManager.PlaySFX(audioManager.click);
        setting.SetActive(false);
    }
}
