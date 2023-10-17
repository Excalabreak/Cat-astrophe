using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    //public static ScoreManager instance;

    //public GameOverScreen GameOverScreen;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;

   // [SerializeField]
    //private TMP_InputField inputName;
    //[SerializeField]
    //private  TextMeshProUGUI inputScore;

    //public UnityEvent<string, int> submitScoreEvent;

    static int score = 0;
    int highscore = 0;
    //needs the total score
    static int scoreGoal;

    //private void Awake()
    //{
        //instance = this;
    //}
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString() + " POINTS";
        //inputScore.text = score.ToString() + " SCORE";
        highscoreText.text = "HIGHSCORE: " + highscore.ToString();
    }

    //needs fix
    public void AddPoint()
    {
        score += 1;
        scoreText.text = score.ToString() + " PIONTS";
        //inputScore.text = score.ToString() + " SCORE";
        if (highscore < score)
        {
            PlayerPrefs.SetInt("highscore", score);
        }
    }

    //needs fix
    public void DeductPoint()
    {
        score -= 1;
    }

    //public void SubmitScore()
    //{
    // submitScoreEvent.Invoke(inputName.text, int.Parse(inputScore.text));
    //}

    //only if the cone of shame and the timer runs out
    // public void GameOver()
    //{
    //  GameOverScreen.Setup();
    //}

    private void OnGUI()
    {
        GUILayout.Box("score: " + score);
    }

    private void Update()
    {
        if (score >= scoreGoal)
        {
            score = 0;
            //SceneManager.LoadScene("3");
        }
    }
}
