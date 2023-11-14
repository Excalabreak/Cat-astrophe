using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject optionScreen;
    public GameObject levelSelection;

    AudioManager audioManager;

    private ScoreManager scoreManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        scoreManager = FindAnyObjectByType<ScoreManager>();
        audioManager.PlayMusic(audioManager.MainMenu);
    }

    public void Level1()
    {
        audioManager.PlaySFX(audioManager.click);
        SceneManager.LoadScene(1);
        ScoreManager.scoreCount = 0;
    }
    
    public void Level2()
    {
        audioManager.PlaySFX(audioManager.click);
        SceneManager.LoadScene(4);
        ScoreManager.scoreCount = 0;
    } 
    
    public void Level3()
    {
        audioManager.PlaySFX(audioManager.click);
        //SceneManager.LoadScene();
        ScoreManager.scoreCount = 0;
    }

    public void OpenOption()
    {
        audioManager.PlaySFX(audioManager.click);
        optionScreen.SetActive(true);
    }
    
    public void OpenLevelSelection()
    {
        audioManager.PlaySFX(audioManager.click);
        levelSelection.SetActive(true);
    }

    public void CloseOption()
    {
        audioManager.PlaySFX(audioManager.click);
        optionScreen.SetActive(false);
    }
    
    public void CloseLevelSelection()
    {
        audioManager.PlaySFX(audioManager.click);
        levelSelection.SetActive(false);
    }

    public void QuitGame()
    {
        audioManager.PlaySFX(audioManager.click);
        Application.Quit();
        Debug.Log("Quitting");
    }
}
