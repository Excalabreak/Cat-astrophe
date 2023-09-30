using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Speak : MonoBehaviour
{
    //Variable for sounds
    [SerializeField] private AudioSource meow;
    [SerializeField] private AudioSource purr;
    [SerializeField] private bool sleeping;
    private float timing;

    // Update is called once per frame
    void FixedUpdate()
    {
        Meow();

        Purr();

    }

    // Press [F] for meow
    private void Meow()
    {
        if (Keyboard.current.fKey.wasPressedThisFrame)
        {
            meow.Play();
        }
    }

    // Cat purring
    private void Purr()
    {
        if (Keyboard.current.qKey.isPressed)
        {
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
