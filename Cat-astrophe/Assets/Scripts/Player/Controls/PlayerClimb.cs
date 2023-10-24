using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClimb : MonoBehaviour
{
    //var reference
    [SerializeField] private Transform orientation;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private LayerMask wallLayers;
    private InputManager inputManager;
    private PlayerMotion playerMotion;

    //var for climbing
    [SerializeField] private float climbSpeed = 10f;
    [SerializeField] private float maxClimbTime = .75f;
    private float climbTimer;

    //bool if player is climbing
    private bool climbing;
    //private bool startedClimbing = false;

    //var to detect when player is next to a wall
    [SerializeField] private float detectionLength = .7f;
    [SerializeField] private float sphereCastRadius = .25f;
    [SerializeField] private float maxWallLookAngle = 30f;
    private float wallLookAngle;
    private RaycastHit frontWallHit;
    private bool wallFront;

    //climb jump
    private bool doClimbJump = false;
    [SerializeField] private float climbJumpUpForce = 14f;
    [SerializeField] private float climbJumpBackForce = 12f;

    [SerializeField] private int climbJumps = 1;
    private int climbJumpLeft;

    private Transform lastWall;
    private Vector3 lastWallNormal;
    [SerializeField] private float minWallNormalAngle = 5;

    //get the other scripts
    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        playerMotion = GetComponent<PlayerMotion>();
    }

    /// <summary>
    /// called every frame to climb
    /// </summary>
    public void HandleClimbing()
    {
        WallCheck();

        StateMachine();
        if (climbing)
        {
            HandleClimbingMovement();
        }
    }

    /// <summary>
    /// state machine for how to climb
    /// </summary>
    private void StateMachine()
    {
        if (wallFront && (Mathf.Abs(inputManager.VerticalInput) >= 0 || Mathf.Abs(inputManager.HorizontalInput) >= 0) && wallLookAngle < maxWallLookAngle)
        {
            if (!climbing && climbTimer > 0)
            {
                StartClimbing();
            }

            if (climbTimer > 0)
            {
                climbTimer -= Time.deltaTime;
            }
            if (climbTimer < 0)
            {
                StopClimbing();
            }
        }
        else
        {
            if (climbing)
            {
                StopClimbing();
            }
        }

        if (wallFront && doClimbJump && climbJumpLeft > 0)
        {
            doClimbJump = false;
            ClimbJump();
        }
    }

    /// <summary>
    /// checks if the wall is infront of the player
    /// </summary>
    private void WallCheck()
    {
        wallFront = Physics.SphereCast(transform.position, sphereCastRadius, orientation.forward, out frontWallHit, detectionLength, wallLayers);
        wallLookAngle = Vector3.Angle(orientation.forward, -frontWallHit.normal);

        bool newWall = frontWallHit.transform != lastWall || Mathf.Abs(Vector3.Angle(lastWallNormal, frontWallHit.normal)) > minWallNormalAngle;

        if ((wallFront && newWall) || playerMotion.IsGrounded)
        {
            climbTimer = maxClimbTime;
            climbJumpLeft = climbJumps;
        }
    }

    /// <summary>
    /// called when the player starts climbing
    /// </summary>
    private void StartClimbing()
    {
        climbing = true;

        lastWall = frontWallHit.transform;
        lastWallNormal = frontWallHit.normal;
    }

    /// <summary>
    /// makes player go up when climbing
    /// </summary>
    private void HandleClimbingMovement()
    {
        //rb.velocity.z
        if (Mathf.Abs(inputManager.VerticalInput) >= Mathf.Abs(inputManager.HorizontalInput))
        {
            rb.velocity = new Vector3(0, climbSpeed * Mathf.Abs(inputManager.VerticalInput), 0);
        }
        else
        {
            rb.velocity = new Vector3(0, climbSpeed * Mathf.Abs(inputManager.HorizontalInput), 0);
        }
    }

    /// <summary>
    /// called when the player starts climbing
    /// </summary>
    private void StopClimbing()
    {
        climbing = false;
    }

    /// <summary>
    /// jump when climbing
    /// </summary>
    private void ClimbJump()
    {
        Vector3 forceToApply = transform.up * climbJumpUpForce + frontWallHit.normal * climbJumpBackForce;

        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(forceToApply, ForceMode.Impulse);

        climbJumpLeft--;
    }

    public bool Climbing
    {
        get { return climbing; }
    }

    public bool DoClimbJump
    {
        set { doClimbJump = value; }
    }
}
