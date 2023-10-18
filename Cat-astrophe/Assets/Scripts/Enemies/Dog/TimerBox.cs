using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerBox : MonoBehaviour
{
    //Variables for UI
    [SerializeField] Slider sliderObj;
    private float sliderTime = 5f;

    // Start is called before the first frame update
    private void Start()
    {
        sliderObj.maxValue = sliderTime;
        sliderObj.value = sliderTime;
        TimeOut();
    }

    // Function for TimeOut
    private void TimeOut()
    {
        StartCoroutine(ToWait());
    }

    // Corutine for timing
    IEnumerator ToWait()
    {
        sliderTime -= Time.deltaTime;
        yield return new WaitForSeconds(0.001f);   
    }
}
