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

    //on awake, get set refences
    private void Awake()
    {
        playerMotion = GetComponent<PlayerMotion>();
        scratchScript = GetComponent<ScratchScript>();
    }

    /// <summary>
    /// sets first warning to true
    /// </summary>
    public void GiveFirstWarning()
    {
        firstWarning = true;
    }

    /// <summary>
    /// cone of shame is set to true and calls for move debuffs
    /// </summary>
    public void AddConeOfShame()
    {
        hasConeOfShame = true;
        coneMR.enabled = true;
        playerMotion.HandleConeOfShame();
    }

    /// <summary>
    /// shows game over screen and sets player is set to false
    /// </summary>
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

    /// <summary>
    /// does player have cone of shame
    /// </summary>
    public bool HasConeOfShame
    {
        get { return hasConeOfShame; }
    }
    
    /// <summary>
    /// did the player get a first warning
    /// </summary>
    public bool FirstWarning
    {
        get { return firstWarning; }
    }
}
