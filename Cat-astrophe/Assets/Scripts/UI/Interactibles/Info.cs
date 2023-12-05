using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Info : MonoBehaviour
{
    //AudioManager audioManager;
    public static bool pausedInfo = false;

    public GameObject pauseMenu;

    //public TextMeshProUGUI objectiveNameText;
    //public TextMeshProUGUI demenstrateInfoText;

    PauseAction action;

    private void Awake()
    {
        action = new PauseAction();
        //audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnEnable()
    {
        action.Enable();
    }

    private void OnDisable()
    {
        action.Disable();
    }

    private void Start()
    {
        action.Pause.InfoPause.performed += _ => DeterminePause();
    }

    //private void Update()
    //{
    //    if (pausedInfo && Input.GetKeyDown(KeyCode.Tab))
    //    {
    //        //print("Info Started");
    //        //objectiveNameText.text = " ";
    //        //objectiveNameText.text = " ";
    //        DeterminePause();
    //    }
    //}

    private void DeterminePause()
    {
        if (pausedInfo)
        {
            //playerInteract = false;
            ResumeGame();
        }
        else
        {
            //playerInteract = true;
            PauseGame();
        }
    }

    public void PauseGame()
    {
        //audioManager.PlaySFX(audioManager.click);
        //Time.timeScale = 0;
        //AudioListener.pause = true;
        pauseMenu.SetActive(true);
        pausedInfo = true;
    }

    public void ResumeGame()
    {
        //audioManager.PlaySFX(audioManager.click);
        //Time.timeScale = 1;
        //AudioListener.pause = false;
        pauseMenu.SetActive(false);
        pausedInfo = false;
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.name == "Player")
    //    {
    //        //playerInteract = true;
    //        PauseGame();
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    //playerInteract = false;
    //    ResumeGame();
    //}
}
