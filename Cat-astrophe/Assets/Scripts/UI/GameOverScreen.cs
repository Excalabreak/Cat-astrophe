using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene(1);
        SFXManager.sxfInstance.Audio.PlayOneShot(SFXManager.sxfInstance.Click);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        SFXManager.sxfInstance.Audio.PlayOneShot(SFXManager.sxfInstance.Click);
    }
}
