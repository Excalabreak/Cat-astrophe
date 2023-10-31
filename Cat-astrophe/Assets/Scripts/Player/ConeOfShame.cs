using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConeOfShame : MonoBehaviour
{
    private PlayerMotion playerMotion;
    private ScratchScript scratchScript;

    private bool wasWarned = false;

    //mesh renderer for cone of shame
    [SerializeField] private MeshRenderer coneMR;

    private void Awake()
    {
        playerMotion = GetComponent<PlayerMotion>();
        scratchScript = GetComponent<ScratchScript>();
    }

    public void AddConeOfShame()
    {
        wasWarned = true;
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
        coneMR.enabled = false;
        playerMotion.ResetStats();
        wasWarned = false;
    }

    public bool WasWarned
    {
        get { return wasWarned; }
    }
}
