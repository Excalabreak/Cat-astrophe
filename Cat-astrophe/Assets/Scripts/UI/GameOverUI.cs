using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private Text titleText;
    [SerializeField] private float ConeOfShameTextTime = 3f;

    /// <summary>
    /// game over screen
    /// </summary>
    public void SetUpGameOverUI()
    {
        titleText.text = "GAME OVER";

        titleText.enabled = true;
    }

    /// <summary>
    /// game over screen
    /// </summary>
    public void SetUpConeOfShameUI()
    {
        titleText.text = "You got caught, CONE OF SHAME";

        StartCoroutine(textTimer());
    }

    private IEnumerator textTimer()
    {
        titleText.enabled = true;

        yield return new WaitForSeconds(ConeOfShameTextTime);

        titleText.enabled = false;
    }
}
