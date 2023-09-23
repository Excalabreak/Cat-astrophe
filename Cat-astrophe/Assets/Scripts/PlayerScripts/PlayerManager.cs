using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private InputManager inputManager;
    private PlayerMotion playerMotion;

    /*
     * On Awake:
     * 
     * Sets the inputManager, playerMotion
     */
    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        playerMotion = GetComponent<PlayerMotion>();
    }

    /*
     * On every frame:
     * 
     * Sets variables to move player
     */
    private void Update()
    {
        inputManager.HandleAllInputs();

    }

    /*
     * On every physics frame:
     * 
     * Moves the Player
     */
    private void FixedUpdate()
    {
        playerMotion.HandleAllMovement();
    }
}
