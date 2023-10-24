using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;

    static int score = 0;
    int highscore = 0;
    //needs the total score
    static int scoreGoal;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = score.ToString() + " POINTS";
        highscoreText.text = "HIGHSCORE: " + highscore.ToString();
    }

    //needs fix
    public void AddPoint()
    {
        score += 5;
        scoreText.text = score.ToString() + " POINTS";
        if (highscore < score)
        {
            PlayerPrefs.SetInt("highscore", score);
        }
        else
        {
            highscoreText.text = "Highscore: 0".ToString();
        }
    }

    //needs fix
    public void DeductPoint()
    {
        score -= 5;
        scoreText.text = score.ToString() + " POINTS";
    }

    private void OnGUI()
    {
        GUILayout.Box("score: " + score);
    }

    private void Update()
    {
        if (score >= scoreGoal)
        {
            score = 0;
        }
        else
        {
            score = -10;
            SceneManager.LoadScene(2);
        }
    }
}
