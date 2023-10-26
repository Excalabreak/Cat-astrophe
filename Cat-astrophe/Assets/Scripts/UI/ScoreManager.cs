using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;

    public static int scoreCount;
    public static int highScoreCount;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScoreCount = PlayerPrefs.GetInt("HighScore");
        }
    }

    private void Update()
    {
        //highscore record
        if (scoreCount > highScoreCount)
        {
            highScoreCount = scoreCount;
            PlayerPrefs.SetInt("HighScore", highScoreCount);
        }

        //score count in UI and can add from other scripts
        scoreText.text = "Score: " + Mathf.Round(scoreCount);
        highscoreText.text = "HighScore: " + highScoreCount;
    }

    void OnDisable()
    {
        PlayerPrefs.SetInt("Score: ", scoreCount);
    }
}
