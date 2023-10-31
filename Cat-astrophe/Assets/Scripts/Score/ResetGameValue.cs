using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGameValue : MonoBehaviour
{
    private ScoreManager scoreManager;

    private void Start()
    {
        scoreManager = FindAnyObjectByType<ScoreManager>();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(1);
        ScoreManager.scoreCount = 0;
    }
}
