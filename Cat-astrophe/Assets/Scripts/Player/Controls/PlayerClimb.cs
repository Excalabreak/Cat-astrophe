using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClimb : MonoBehaviour
{
    //var reference
    [SerializeField] private Transform orientation;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private LayerMask wallLayers;

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

    private void Update()
    {
        WallCheck();
    }

    private void WallCheck()
    {
        wallFront = Physics.SphereCast(transform.position, sphereCastRadius, orientation.forward, out frontWallHit, detectionLength, wallLayers);
        wallLookAngle = Vector3.Angle(orientation.forward, -frontWallHit.normal);
    }


}
