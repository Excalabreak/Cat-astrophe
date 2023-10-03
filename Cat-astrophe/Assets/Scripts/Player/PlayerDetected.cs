using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetected : MonoBehaviour
{
    //bool if the cat is detected or not
    public bool isDetected = false;

    private bool handleCalled = false;

    private void FixedUpdate()
    {
        if (!handleCalled)
        {
            isDetected = false;
        }
        handleCalled = false;
    }

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
