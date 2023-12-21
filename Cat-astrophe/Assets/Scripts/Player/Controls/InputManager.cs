using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    //gets input from controller
    private PlayerControls playerControls;

    private PlayerMotion playerMotion;
    private ScratchScript scratchScript;
    private PlayerClimb playerClimb;
    private PickUp2 pickUp;

    //what is the input from the controller
    private Vector2 moveInput;
    private float verticalInput;
    private float horizontalInput;

    //what is the camera input from the controller
    private Vector2 cameraInput;
    private float cameraInputX;
    private float cameraInputY;

    //variables for jump
    private bool jumpInput;

    //variables for scrach
    private bool scratchInput;

    //variables for pick up items
    private bool pickUpInput;
    private bool tossInput;

    //on awake: get PlayerMotion
    private void Awake()
    {
        playerMotion = GetComponent<PlayerMotion>();
        scratchScript = GetComponent<ScratchScript>();
        playerClimb = GetComponent<PlayerClimb>();
        pickUp = GetComponent<PickUp2>();
    }

    /*
     * When the object(player) this is on is enabled:
     * sets all the callback context for each input
     */
    private void OnEnable()
    {
        if (playerControls == null)
        {
            playerControls = new PlayerControls();

            playerControls.PlayerMovement.Movement.performed += i => moveInput = i.ReadValue<Vector2>();
            playerControls.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();

            playerControls.PlayerActions.Jump.performed += i => jumpInput = true;
            playerControls.PlayerActions.Scratch.performed += i => scratchInput = true;
            playerControls.PlayerActions.PickUp.performed += i => pickUpInput = true;
            playerControls.PlayerActions.Toss.performed += i => tossInput = true;
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
        HandleJumpInput();
        HandleScrachInput();
        HandleTossInput();
        HandlePickUpInput();
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

    /// <summary>
    /// when the player jumps, turn off jumpInput for only one jump and calls HandleJump in playerMotion
    /// </summary>
    private void HandleJumpInput()
    {
        if (jumpInput)
        {
            jumpInput = false;

            if (playerClimb.Climbing)
            {
                playerClimb.DoClimbJump = true;
            }
            else
            {
                playerMotion.HandleJump();
            }
        }
    }

    /// <summary>
    /// when the player scraches, turn off scrachInput and calls HandleScrach in ScrachScript
    /// </summary>
    private void HandleScrachInput()
    {
        if (scratchInput)
        {
            scratchInput = false;
            scratchScript.HandleScratch();
        }
    }

    /// <summary>
    /// when the player tosses, turn off tossInput and calls HandleToss in PickUp2
    /// </summary>
    private void HandleTossInput()
    {
        if (tossInput)
        {
            tossInput = false;
            pickUp.HandleToss();
        }
    }

    /// <summary>
    /// when the player pick ups, turn off pickUpInput and calls HandleToss in PickUp2
    /// </summary>
    private void HandlePickUpInput()
    {
        if (pickUpInput)
        {
            pickUpInput = false;
            pickUp.HandlePickUp();
        }
    }

    /// <summary>
    /// get the forward and back inputs
    /// </summary>
    public float VerticalInput
    {
        get { return verticalInput; }
    }

    /// <summary>
    /// get the left and right inputs
    /// </summary>
    public float HorizontalInput
    {
        get { return horizontalInput; }
    }

    /// <summary>
    /// get the x input for camera
    /// </summary>
    public float CameraInputX
    {
        get { return cameraInputX; }
    }

    /// <summary>
    /// get the y input for camera
    /// </summary>
    public float CameraInputY
    {
        get { return cameraInputY; }
    }
}
