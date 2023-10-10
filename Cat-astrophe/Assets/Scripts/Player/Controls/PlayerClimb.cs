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

    //var to detect when player is next to a wall
    [SerializeField] private float detectionLength = .7f;
    [SerializeField] private float sphereCastRadius = .25f;
    [SerializeField] private float maxWallLookAngle = 30f;
    private float wallLookAngle;
    private RaycastHit frontWallHit;
    private bool wallFront;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        playerMotion = GetComponent<PlayerMotion>();
    }

    private void Update()
    {
        WallCheck();

        StateMachine();
        if (climbing)
        {
            HandleClimbingMovement();
        }
    }

    private void StateMachine()
    {
        if (wallFront && inputManager.VerticalInput > 0 && wallLookAngle < maxWallLookAngle)
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
    }

    private void WallCheck()
    {
        wallFront = Physics.SphereCast(transform.position, sphereCastRadius, orientation.forward, out frontWallHit, detectionLength, wallLayers);
        wallLookAngle = Vector3.Angle(orientation.forward, -frontWallHit.normal);

        if (playerMotion.IsGrounded)
        {
            climbTimer = maxClimbTime;
        }
    }

    private void StartClimbing()
    {
        climbing = true;
    }

    private void HandleClimbingMovement()
    {
        rb.velocity = new Vector3(rb.velocity.x, climbSpeed, rb.velocity.z);
    }

    private void StopClimbing()
    {
        climbing = false;
    }
}
