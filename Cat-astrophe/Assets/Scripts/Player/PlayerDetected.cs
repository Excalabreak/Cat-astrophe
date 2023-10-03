using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetected : MonoBehaviour
{
    //bool if the cat is detected or not
    private bool isDetected = false;

    //bool if the handle detection was called this fix update
    private bool handleCalled = false;

    //checks if it is still detected
    private void FixedUpdate()
    {
        if (!handleCalled)
        {
            isDetected = false;
        }
        handleCalled = false;
    }

    //called when a camera has detected player
    public void HandleDetection()
    {
        isDetected = true;
        handleCalled = true;
    }

    public bool IsDetected
    {
        get { return isDetected; }
    }
}
