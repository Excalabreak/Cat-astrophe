using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject optionScreen;
    public GameObject levelSelection;


    private ScoreManager scoreManager;

    private void Start()
    {
        scoreManager = FindAnyObjectByType<ScoreManager>();
    }

    public void Level1()
    {
        SceneManager.LoadScene(1);
        ScoreManager.scoreCount = 0;
        SFXManager.sxfInstance.Audio.PlayOneShot(SFXManager.sxfInstance.Click);
    }
    
    public void Level2()
    {
        //SceneManager.LoadScene();
        ScoreManager.scoreCount = 0;
        SFXManager.sxfInstance.Audio.PlayOneShot(SFXManager.sxfInstance.Click);
    } 
    
    public void Level3()
    {
        //SceneManager.LoadScene();
        ScoreManager.scoreCount = 0;
        SFXManager.sxfInstance.Audio.PlayOneShot(SFXManager.sxfInstance.Click);
    }

    public void OpenOption()
    {
        optionScreen.SetActive(true);
        SFXManager.sxfInstance.Audio.PlayOneShot(SFXManager.sxfInstance.Click);
    }
    
    public void OpenLevelSelection()
    {
        levelSelection.SetActive(true);
        SFXManager.sxfInstance.Audio.PlayOneShot(SFXManager.sxfInstance.Click);
    }

    public void CloseOption()
    {
        optionScreen.SetActive(false);
        SFXManager.sxfInstance.Audio.PlayOneShot(SFXManager.sxfInstance.Click);
    }
    
    public void CloseLevelSelection()
    {
        levelSelection.SetActive(false);
        SFXManager.sxfInstance.Audio.PlayOneShot(SFXManager.sxfInstance.Click);
    }

    public void QuitGame()
    {
        Application.Quit();
        SFXManager.sxfInstance.Audio.PlayOneShot(SFXManager.sxfInstance.Click);
        Debug.Log("Quitting");
    }
}
