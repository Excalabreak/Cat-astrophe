using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    private ScoreManager scoreManager;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        audioManager.PlayMusic(audioManager.GameOverMenu);
        scoreManager = FindAnyObjectByType<ScoreManager>();
    }

    public void Restart()
    {
        audioManager.PlaySFX(audioManager.click);
        SceneManager.LoadScene(1);
        ScoreManager.scoreCount = 0;
    }

    public void MainMenu()
    {
        audioManager.PlaySFX(audioManager.click);
        SceneManager.LoadScene(0);
    }

    public void Level2()
    {
        audioManager.PlaySFX(audioManager.click);
        SceneManager.LoadScene(4);
    }
}
