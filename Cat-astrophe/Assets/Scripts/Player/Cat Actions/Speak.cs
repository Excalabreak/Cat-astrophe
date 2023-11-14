using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Speak : MonoBehaviour
{
    //Variable for sounds
    //[SerializeField] private AudioSource meow;
    [SerializeField] private AudioSource purr;
    [SerializeField] private bool sleeping;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Meow();

        Purr();
           
    }

    // Press [F] for meow
    private void Meow()
    {
        if (Keyboard.current.fKey.wasPressedThisFrame)
        {
            //meow.Play();
            audioManager.PlaySFX(audioManager.meow);
        }
    }

    // Cat purring
    private void Purr()
    {
        if (Keyboard.current.qKey.isPressed)
        {
            //audioManager.PlaySFX(audioManager.pur);
            if (sleeping == false)
            {
                sleeping = true;
                purr.Play();
            }
        }
        else
        {
            purr.Stop();
            sleeping = false;

        }

    }
}
