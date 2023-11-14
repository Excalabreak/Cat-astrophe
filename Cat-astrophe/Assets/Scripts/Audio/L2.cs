using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2 : MonoBehaviour
{
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        audioManager.PlayMusic(audioManager.Level2);
    }
}
