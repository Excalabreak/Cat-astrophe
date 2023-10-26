using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class LeaderScore : MonoBehaviour
{
    ScoreManager addPoints;

    [SerializeField]
    private TextMeshProUGUI inputScore;

    [SerializeField]
    private TMP_InputField inputName;

    public UnityEvent<string, int> submitScoreEvent;

    private void Awake()
    {
        addPoints = gameObject.GetComponent<ScoreManager>();
    }

    private void Update()
    {
        addPoints.AddPoint();
        inputScore.text = addPoints.ToString() + " ";
        
    }

    public void SubmitScore()
    {
        submitScoreEvent.Invoke(inputName.text, int.Parse(inputScore.text));
    }
}
