using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetected : MonoBehaviour
{
    private PlayerMotion playerMotion;

    //bool if the cat is detected or not
    private bool isDetected = false;

    //bool if the handle detection was called this fix update
    private bool handleCalled = false;

    //model so player can know if they are being detected
    [SerializeField] private GameObject alertModel;

    //bool for blanket power up
    private bool blanket = false;
    [SerializeField] private GameObject blanketModel;
    [SerializeField] private float blanketTime = 15f;

    //gets scripts that are needed
    private void Awake()
    {
        playerMotion = GetComponent<PlayerMotion>();
    }

    //checks if it is still detected
    private void FixedUpdate()
    {
        if (!handleCalled)
        {
            isDetected = false;
            HideAlert();
        }
        handleCalled = false;
    }

    /// <summary>
    /// called when a camera has detected player
    /// </summary>
    public void HandleDetection()
    {
        if (!blanket)
        {
            isDetected = true;
            handleCalled = true;
            ShowAlert();
        }
    }
    
    /// <summary>
    /// starts blanket coroutine
    /// </summary>
    public void HandleBlanket()
    {
        StartCoroutine(BlanketBuff());
    }

    /// <summary>
    /// shows model for alert
    /// </summary>
    public void ShowAlert()
    {
        alertModel.SetActive(true);
    }

    /// <summary>
    /// hides alert model
    /// </summary>
    public void HideAlert()
    {
        alertModel.SetActive(false);
    }

    /// <summary>
    /// shows model for blanket
    /// </summary>
    private void ShowBlanket()
    {
        blanketModel.SetActive(true);
    }

    /// <summary>
    /// hides blanket model
    /// </summary>
    private void HideBlanket()
    {
        blanketModel.SetActive(false);
    }

    /// <summary>
    /// coroutine for blanket powerup
    /// </summary>
    /// <returns></returns>
    private IEnumerator BlanketBuff()
    {
        blanket = true;
        playerMotion.HandleBlanketDebuff();
        ShowBlanket();

        yield return new WaitForSeconds(blanketTime);

        blanket = false;
        playerMotion.RemoveBlanketDebuff();
        HideBlanket();
    }

    public bool IsDetected
    {
        get { return isDetected; }
    }

    public bool Blanket
    {
        get { return blanket; }
    }
}
