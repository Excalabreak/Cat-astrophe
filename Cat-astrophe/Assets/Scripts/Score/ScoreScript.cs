using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    /// <summary>
    /// adds score to score manager
    /// </summary>
    /// <param name="s">how many points does the player get</param>
    public void AddScore(int s)
    {
        GameScoreManager.Instance.AddToScore(s);
    }
}
