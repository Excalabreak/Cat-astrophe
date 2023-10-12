using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    //make this a singleton
    private static ScoreManager instance;

    //total score of the game
    [SerializeField] private int score = 0;

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
