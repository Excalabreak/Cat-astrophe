using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    //ints for how many points is awarded when damaged or destroy
    [SerializeField] private int damageScore = 1;
    [SerializeField] private int destroyScore = 2;

    public void AddDamageScore()
    {
        ScoreManager.Instance.AddToScore(damageScore);
    }

    public void AddDestroyScore()
    {
        ScoreManager.Instance.AddToScore(destroyScore);
    }
}
