using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class LeaderScore : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI inputScore;

    [SerializeField]
    private TextMeshProUGUI _inputScore;

    [SerializeField]
    private TMP_InputField inputName;

    static int score = 0;

    public UnityEvent<string, int> submitScoreEvent;

    private void Start()
    {
        score = PlayerPrefs.GetInt("Score: ");
        CursorManager.Instance.ShowCursor();
    }

    private void Update()
    {
        _inputScore.text = "" + score;
    }

    public void SubmitScore()
    {
        submitScoreEvent.Invoke(inputName.text, int.Parse(inputScore.text));
    }
}
