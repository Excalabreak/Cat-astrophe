using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    private ScoreManager scoreManager;
    public GameObject leaderBoardMenu;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        audioManager.PlayMusic(audioManager.GameOverMenu);
        audioManager.PlaySFX(audioManager.sad);
        scoreManager = FindAnyObjectByType<ScoreManager>();
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

    public void QuitGame()
    {
        audioManager.PlaySFX(audioManager.click);
        Application.Quit();
        Debug.Log("Quitting");
    }

    public void OpenLeaderBoard()
    {
        audioManager.PlaySFX(audioManager.click);
        leaderBoardMenu.SetActive(true);
    } 
    
    public void CloseLeaderBoard()
    {
        audioManager.PlaySFX(audioManager.click);
        leaderBoardMenu.SetActive(false);
    }
}
