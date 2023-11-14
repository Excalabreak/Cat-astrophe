using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryMenu : MonoBehaviour
{
    private ScoreManager scoreManager;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        scoreManager = FindAnyObjectByType<ScoreManager>();
        audioManager.PlayMusic(audioManager.VictoryMenu);
        CursorManager.Instance.ShowCursor();
    }

    public void Restart()
    {
        audioManager.PlaySFX(audioManager.click);
        SceneManager.LoadScene(1);
        ScoreManager.scoreCount = 0;
        CursorManager.Instance.HideCursor();
    }

    public void MainMenu()
    {
        audioManager.PlaySFX(audioManager.click);
        SceneManager.LoadScene(0);
        CursorManager.Instance.ShowCursor();
    }

    public void Level2()
    {
        audioManager.PlaySFX(audioManager.click);
        ScoreManager.scoreCount = PlayerPrefs.GetInt("Score: ");
        SceneManager.LoadScene(4);
        CursorManager.Instance.HideCursor();
    }

    public void QuitGame()
    {
        audioManager.PlaySFX(audioManager.click);
        Application.Quit();
        Debug.Log("Quitting");
    }
}
