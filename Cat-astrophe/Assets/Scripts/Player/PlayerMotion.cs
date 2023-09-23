using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotion : MonoBehaviour
{
    //components needed for this scripts (cameraObject is for main camera)
    [SerializeField] private Transform cameraObject;
    private InputManager inputManager;
    private Rigidbody playerRigidBody;

    //setable speeds in editor
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float rotationSpeed = 15f;

    //the direction where it rotates
    private Vector3 moveDirection;

    //variables for falling
    private bool isGrounded;
    private float inAirTimer;
    [SerializeField] private float rayCastHeightOffset = 0.5f;
    [SerializeField] private float leapingVelocity;
    [SerializeField] private float fallingSpeed;
    [SerializeField] private LayerMask groundLayer;

    //on awake:
    //sets the input manager and rigid body
    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        playerRigidBody = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Calls all Handle functions in this script
    /// (Movement, Rotation)
    /// </summary>
    public void HandleAllMovement()
    {
        HandleFalling();
        HandleMovement();
        HandleRotation();
    }

    /// <summary>
    /// This method gets the input from input manager 
    /// and moves the object in that direction
    /// </summary>
    private void HandleMovement()
    {
        moveDirection = cameraObject.forward * inputManager.VerticalInput;
        moveDirection = moveDirection + cameraObject.right * inputManager.HorizontalInput;
        moveDirection.Normalize();
        moveDirection.y = 0;
        moveDirection = moveDirection * moveSpeed;

        playerRigidBody.velocity = moveDirection;
    }

    /// <summary>
    /// This method gets the input from input manager 
    /// and rotates the object in the direction it moves
    /// </summary>
    private void HandleRotation()
    {
        Vector3 targetDirection = Vector3.zero;

        targetDirection = cameraObject.forward * inputManager.VerticalInput;
        targetDirection = targetDirection + cameraObject.right * inputManager.HorizontalInput;
        targetDirection.Normalize();
        targetDirection.y = 0;

        if (targetDirection == Vector3.zero)
        {
            targetDirection = transform.forward;
        }

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        transform.rotation = playerRotation;
    }

    /// <summary>
    /// This function will allow the player to fall
    /// </summary>
    private void HandleFalling()
    {
        RaycastHit hit;
        Vector3 rayCastOrigin = transform.position;
        rayCastOrigin.y = rayCastOrigin.y + rayCastHeightOffset;

        if (!isGrounded)
        {
            inAirTimer = inAirTimer + Time.deltaTime;
            playerRigidBody.AddForce(transform.forward * leapingVelocity);
            playerRigidBody.AddForce(-Vector3.up * fallingSpeed * inAirTimer);
        }

        if (Physics.SphereCast(rayCastOrigin, 0.2f, -Vector3.up, out hit, groundLayer))
        {
            inAirTimer = 0;
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}
