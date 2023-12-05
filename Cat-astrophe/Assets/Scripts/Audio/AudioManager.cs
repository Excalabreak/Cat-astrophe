using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //for all the other scripts
    //AudioManager audioManager;
    //Awake audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    //audioManager.PlaySFX(audioManager. );
    [SerializeField]
    AudioSource musicSource;
    [SerializeField]
    AudioSource SFXSource;

    public AudioClip MainMenu;
    public AudioClip PauseMenu;
    public AudioClip GameOverMenu;
    public AudioClip VictoryMenu;
    public AudioClip Level1;
    public AudioClip Level2;
    public AudioClip click;
    public AudioClip eat;
    public AudioClip scratch;
    public AudioClip pur;
    public AudioClip meow;
    public AudioClip sad;
    public AudioClip didIt;
    public AudioClip mad;
    public AudioClip dog;
    public AudioClip mouse;
    public AudioClip brokenGlass;
    public AudioClip brokenCamera;
    

    //private void Start()
    //{
    //    musicSource.clip = bg;
    //    musicSource.Play();
    //}

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void PlayMusic(AudioClip music)
    {
        musicSource.PlayOneShot(music);
    }
}
