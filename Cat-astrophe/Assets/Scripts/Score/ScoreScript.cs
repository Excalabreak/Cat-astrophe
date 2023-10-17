using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    public void AddScore(int s)
    {
        GameScoreManager.Instance.AddToScore(s);
    }
}
