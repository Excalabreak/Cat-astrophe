using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeOfShame : MonoBehaviour
{
    private PlayerMotion playerMotion;
    private ScratchScript scratchScript;

    //mesh renderer for cone of shame
    [SerializeField] private MeshRenderer coneMR;

    private void Awake()
    {
        playerMotion = GetComponent<PlayerMotion>();
        scratchScript = GetComponent<ScratchScript>();
    }

    public void AddConeOfShame()
    {
        coneMR.enabled = true;
        playerMotion.HandleConeOfShame();
    }

    /// <summary>
    /// removes Cone of shame from cat
    /// </summary>
    public void ResetConeOfShame()
    {
        coneMR.enabled = false;
        playerMotion.ResetStats();
        scratchScript.WasWarned = false;
    }
}
