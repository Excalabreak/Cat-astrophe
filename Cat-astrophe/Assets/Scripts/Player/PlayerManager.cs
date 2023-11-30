using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //manangers
    private InputManager inputManager;
    private PlayerMotion playerMotion;
    private CameraManager cameraManager;
    private PlayerClimb playerClimb;

    /*
     * On Awake:
     * 
     * Sets the inputManager, playerMotion
     */
    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        playerMotion = GetComponent<PlayerMotion>();
        playerClimb = GetComponent<PlayerClimb>();
        cameraManager = FindObjectOfType<CameraManager>();
    }

    /*
     * On every frame:
     * 
     * Sets variables to move player
     */
    private void Update()
    {
        //pause game
        if (PauseManager.paused) return;
        if (Info.pausedInfo) return;
        inputManager.HandleAllInputs();
    }

    /*
     * On every physics frame:
     * 
     * Moves the Player
     */
    private void FixedUpdate()
    {
        playerClimb.HandleClimbing();
        playerMotion.HandleAllMovement();
    }

    /*
     * after every frame has ended:
     * 
     * camera fallows target
     */
    private void LateUpdate()
    {
        cameraManager.HandleAllCameraMovement();
    }
}
