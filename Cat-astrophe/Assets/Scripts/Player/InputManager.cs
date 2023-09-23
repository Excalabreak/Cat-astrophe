using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    //gets input from controller
    private PlayerControls playerControls;

    //what is the input from the controller
    private Vector2 moveInput;
    private float verticalInput;
    private float horizontalInput;

    //what is the camera input from the controller
    private Vector2 cameraInput;
    private float cameraInputX;
    private float cameraInputY;

    /*
     * When the object(player) this is on is enabled:
     * creates a PlayerControls if there isnt already one
     * the lambda(=>) is what gets the inputs from the keyboard/controller
     * Enables player Controls
     */
    private void OnEnable()
    {
        if (playerControls == null)
        {
            playerControls = new PlayerControls();

            playerControls.PlayerMovement.Movement.performed += i => moveInput = i.ReadValue<Vector2>();
            playerControls.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();
        }

        playerControls.Enable();
    }
    
    //disables playerControls when object this is on is disabled
    private void OnDisable()
    {
        playerControls.Disable();
    }

    /// <summary>
    /// Calls all Handle functions in this script 
    /// (MovementInput)
    /// </summary>
    public void HandleAllInputs()
    {
        HandleMovementInput();
    }

    /// <summary>
    /// Sets the vertical and horizontal input floats from:
    /// moveInput and cameraInput
    /// </summary>
    private void HandleMovementInput()
    {
        verticalInput = moveInput.y;
        horizontalInput = moveInput.x;

        cameraInputX = cameraInput.x;
        cameraInputY = cameraInput.y;
    }

    public float VerticalInput
    {
        get { return verticalInput; }
    }

    public float HorizontalInput
    {
        get { return horizontalInput; }
    }

    public float CameraInputX
    {
        get { return cameraInputX; }
    }

    public float CameraInputY
    {
        get { return cameraInputY; }
    }
}
