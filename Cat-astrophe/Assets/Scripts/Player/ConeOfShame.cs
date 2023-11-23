using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConeOfShame : MonoBehaviour
{
    private PlayerMotion playerMotion;
    private ScratchScript scratchScript;

    private bool hasConeOfShame = false;
    private bool firstWarning = false;

    //mesh renderer for cone of shame
    [SerializeField] private MeshRenderer coneMR;

    private void Awake()
    {
        playerMotion = GetComponent<PlayerMotion>();
        scratchScript = GetComponent<ScratchScript>();
    }

    public void GiveFirstWarning()
    {
        firstWarning = true;
    }

    public void AddConeOfShame()
    {
        hasConeOfShame = true;
        coneMR.enabled = true;
        playerMotion.HandleConeOfShame();
    }

    public void OnGameOver()
    {
        SceneManager.LoadScene(2);
        gameObject.SetActive(false);
    }

    /// <summary>
    /// removes Cone of shame from cat
    /// </summary>
    public void ResetConeOfShame()
    {
        if (hasConeOfShame)
        {
            coneMR.enabled = false;
            playerMotion.ResetStats();
            hasConeOfShame = false;
        }
    }

    public bool HasConeOfShame
    {
        get { return hasConeOfShame; }
    }
    public bool FirstWarning
    {
        get { return firstWarning; }
    }
}
