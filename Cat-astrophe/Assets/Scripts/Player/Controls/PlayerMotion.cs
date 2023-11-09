using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotion : MonoBehaviour
{
    //components needed for this scripts (cameraObject is for main camera)
    [SerializeField] private Transform cameraObject;
    private InputManager inputManager;
    private Rigidbody playerRigidBody;
    private PlayerClimb playerClimb;

    //setable speeds in editor
    [SerializeField] private float startngMoveSpeed = 7f;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed = 15f;

    //vars for debuff when getting caught once
    [SerializeField] private float moveConeDebuff = 2f;
    [SerializeField] private float jumpConeDebuff = 20f;

    //vars for buffs when get treats
    [SerializeField] private float moveTreatBuff = 3f;
    [SerializeField] private float jumpTreatBuff = 10f;
    [SerializeField] private float treatTime = 10f;

    //vars for debuffs when wearing blanket
    [SerializeField] private float blanketMoveDebuff = 1f;
    [SerializeField] private float blanketJumpDebuff = 15f;

    //the direction where it rotates
    private Vector3 moveDirection;

    //variables for falling
    private bool isGrounded;
    private float inAirTimer;
    [SerializeField] private float rayCastHeightOffset = 0.5f;
    [SerializeField] private float leapingVelocity;
    [SerializeField] private float fallingSpeed;
    private float maxDistance = 1;
    [SerializeField] private LayerMask groundLayer;

    //variables for jumping
    [SerializeField] private float gravityIntensity = 3;
    [SerializeField] private float startingJumpHeight = -30;
    private float jumpHeight;

    //on awake:
    //sets the input manager and rigid body
    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        playerRigidBody = GetComponent<Rigidbody>();
        playerClimb = GetComponent<PlayerClimb>();
        ResetStats();
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
    /// applies debuf to moveSpeed and jumpHeight
    /// </summary>
    public void HandleConeOfShame()
    {
        moveSpeed = moveSpeed - moveConeDebuff;
        jumpHeight = jumpHeight + jumpConeDebuff;
    }

    /// <summary>
    /// starts coroutine for treat buff
    /// </summary>
    public void HandleTreats()
    {
        StartCoroutine(TreatBuff());
    }

    /// <summary>
    /// applies debuff from getting blanket power up
    /// </summary>
    public void HandleBlanketDebuff()
    {
        moveSpeed = moveSpeed - blanketMoveDebuff;
        jumpHeight = jumpHeight + blanketJumpDebuff;
    }

    /// <summary>
    /// removees debuffs from blanket power up
    /// </summary>
    public void RemoveBlanketDebuff()
    {
        moveSpeed = moveSpeed + blanketMoveDebuff;
        jumpHeight = jumpHeight - blanketJumpDebuff;
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
        playerRigidBody.velocity = new Vector3(moveDirection.x, playerRigidBody.velocity.y, moveDirection.z);
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

        if (!isGrounded && !playerClimb.Climbing)
        {
            if (inAirTimer < 1.5f)
            {
                inAirTimer = inAirTimer + Time.deltaTime;
                playerRigidBody.AddForce(transform.forward * leapingVelocity);
                playerRigidBody.AddForce(-Vector3.up * fallingSpeed * inAirTimer);
            }
        }

        if (Physics.SphereCast(rayCastOrigin, 0.2f, -Vector3.up, out hit, maxDistance, groundLayer, QueryTriggerInteraction.Ignore) || playerClimb.Climbing)
        {
            inAirTimer = 0;
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    /// <summary>
    /// handles the motions for jumping
    /// </summary>
    public void HandleJump()
    {
        if (isGrounded)
        {
            float jumpVelocity = Mathf.Sqrt(-2 * gravityIntensity * jumpHeight);
            Vector3 playerVelocity = moveDirection;
            playerVelocity.y = jumpVelocity;
            playerRigidBody.velocity = playerVelocity;
        }
    }   

    /// <summary>
    /// resets moveSpeed and jumpHeight to the original numbers
    /// </summary>
    public void ResetStats()
    {
        moveSpeed = startngMoveSpeed;
        jumpHeight = startingJumpHeight;
    }

    private IEnumerator TreatBuff()
    {
        moveSpeed = moveSpeed + moveTreatBuff;
        jumpHeight = jumpHeight - jumpTreatBuff;

        yield return new WaitForSeconds(treatTime);

        moveSpeed = moveSpeed - moveTreatBuff;
        jumpHeight = jumpHeight + jumpTreatBuff;
    }    

    public bool IsGrounded
    {
        get { return isGrounded; }
    }
}
