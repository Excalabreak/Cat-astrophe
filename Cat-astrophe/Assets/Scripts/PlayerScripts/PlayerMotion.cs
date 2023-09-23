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

    //on awake:
    //sets the input manager and rigid body
    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        playerRigidBody = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Calls all Handle functions in this script
    /// Calls all Handle functions in this script
    /// (Movement, Rotation)
    /// </summary>
    public void HandleAllMovement()
    {
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
}
