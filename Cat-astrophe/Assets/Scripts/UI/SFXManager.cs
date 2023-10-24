using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioSource Audio;
    public AudioClip Click;

    public static SFXManager sxfInstance;

    private void Awake()
    {
        if (sxfInstance != null && sxfInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        sxfInstance = this;
        DontDestroyOnLoad(this);
    }
}
