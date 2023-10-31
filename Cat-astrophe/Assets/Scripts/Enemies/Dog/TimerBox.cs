using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerBox : MonoBehaviour
{
    //Variables for UI
    [SerializeField] Slider sliderObj;
    [SerializeField] float sliderTime = 5f;

    // Awake is called at the start
    private void Awake()
    {
        sliderObj.maxValue = sliderTime;
        //score count in UI
        ScoreManager.scoreCount -= 4;
    }

    // OnEnable is called every frame
    private void OnEnable()
    {
        sliderObj.value = sliderTime;
        StartCoroutine(ToWait());
    }

    // Corutine for timing
    IEnumerator ToWait()
    {
        while (sliderObj.value > 0)
        {
            sliderObj.value = sliderObj.value - 1f;
            yield return new WaitForSeconds(1f);
        }
    }
}
