using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetected : MonoBehaviour
{
    //bool if the cat is detected or not
    private bool isDetected = false;

    //bool if the handle detection was called this fix update
    private bool handleCalled = false;

    //model so player can know if they are being detected
    [SerializeField] private GameObject alertModel;

    //checks if it is still detected
    private void FixedUpdate()
    {
        if (!handleCalled)
        {
            isDetected = false;
            HideAlert();
        }
        handleCalled = false;
    }

    //called when a camera has detected player
    public void HandleDetection()
    {
        isDetected = true;
        handleCalled = true;
        ShowAlert();
    }

    private void ShowAlert()
    {
        alertModel.SetActive(true);
    }

    private void HideAlert()
    {
        alertModel.SetActive(false);
    }

    public bool IsDetected
    {
        get { return isDetected; }
    }
}
