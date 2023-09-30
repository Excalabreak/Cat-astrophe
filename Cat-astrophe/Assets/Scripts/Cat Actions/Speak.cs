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
  

    // Update is called once per frame
    void Update()
    {
        Meow();

        //Purr();
           
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
            sleeping = true;
            purr.Play();
        }
        else
        {
            sleeping = false;
            if (sleeping == false)
            {
                purr.Stop();
            }
        }
        
    }
}
