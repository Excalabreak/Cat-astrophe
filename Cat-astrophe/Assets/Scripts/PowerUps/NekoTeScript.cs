using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NekoTeScript : MonoBehaviour
{
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    //IDEA TO REMEMGER: REMOVE NEKOTE, REDUCE TIME AND/OR CONE OF SHAME AFTER DESTROYING CAMERA
    //GIVES DILEMA OF DESTROYING CAMERAS OR BLOCKING THEM
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<ScratchScript>().PickUpNekoTe();
            audioManager.PlaySFX(audioManager.eat);
            //score count for UI
            ScoreManager.scoreCount += 1;
            Destroy(this.gameObject);
        }
    }
}
