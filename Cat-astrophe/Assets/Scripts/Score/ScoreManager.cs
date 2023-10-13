using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    //make this a singleton
    private static ScoreManager instance;

    //total score of the game
    [SerializeField] private int score = 0;

    //bool so that devs can test resetScore
    public bool testResetScore = false;

    //on awake, make this a singleton (and make sure there is only one)
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    //this update is just to test the score reset
    private void Update()
    {
        if (testResetScore)
        {
            testResetScore = false;
            ResetScore();
        }
    }

    /// <summary>
    /// sets score to 0
    /// </summary>
    public void ResetScore()
    {
        score = 0;
    }

    /// <summary>
    /// add s to total score
    /// </summary>
    /// <param name="s">how many points are added to score</param>
    public void AddToScore(int s)
    {
        score = score + s;
    }

    public static ScoreManager Instance
    {
        get { return instance; }
    }

    public int Score
    {
        get { return score; }
    }
}
