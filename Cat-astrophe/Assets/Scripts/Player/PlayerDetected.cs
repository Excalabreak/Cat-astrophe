using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetected : MonoBehaviour
{
    //bool if the cat is detected or not
    private bool isDetected = false;

    public bool IsDetected
    {
        get { return isDetected; }
        set { isDetected = value; }
    }
}
