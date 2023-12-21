using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlanketScript : MonoBehaviour
{
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    //on trigger, call to handle power up and destroy game object after
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerDetected>().HandleBlanket();
            audioManager.PlaySFX(audioManager.eat);
            //score count in UI
            ScoreManager.scoreCount += 1;
            Destroy(this.gameObject);
        }
    }
}
