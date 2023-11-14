using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    private ScoreManager scoreManager;
    public GameObject leaderboardPanel;

    private void Start()
    {
        scoreManager = FindAnyObjectByType<ScoreManager>();
        CursorManager.Instance.ShowCursor();
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
        ScoreManager.scoreCount = 0;
        SFXManager.sxfInstance.Audio.PlayOneShot(SFXManager.sxfInstance.Click);
        CursorManager.Instance.ShowCursor();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        SFXManager.sxfInstance.Audio.PlayOneShot(SFXManager.sxfInstance.Click);
        CursorManager.Instance.ShowCursor();
    }

    public void Level2()
    {
        SceneManager.LoadScene(4);
        SFXManager.sxfInstance.Audio.PlayOneShot(SFXManager.sxfInstance.Click);
    }

    public void OpenLeaderboard()
    {
        leaderboardPanel.SetActive(true);
        SFXManager.sxfInstance.Audio.PlayOneShot(SFXManager.sxfInstance.Click);
    }
    
    public void CloseLeaderboard()
    {
        leaderboardPanel.SetActive(false);
        SFXManager.sxfInstance.Audio.PlayOneShot(SFXManager.sxfInstance.Click);
    }
}
