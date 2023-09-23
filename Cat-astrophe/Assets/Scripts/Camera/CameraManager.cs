using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    //managers
    private InputManager inputManager;

    //transforms needed for scripts
    [Header("TRANSFORMS")]
    private Transform targetTransform; //object that the camera will fallow
    [SerializeField] private Transform cameraPivot; //object that the camera will pivot on
    private Transform cameraTransform; //object of the camera

    //vars for how fast camera fallows
    [Header("CAMERA FALLOW SPEED")]
    private Vector3 cameraFollowVelocity = Vector3.zero;
    [SerializeField] private float cameraFallowSpeed = 0.2f;

    //var for to rotate camera
    private float lookAngle; //up and down
    private float pivotAngle; //left and right

    //vars for camera collision
    [Header("CAMERA COLLISION")]
    private float defaultPosition;
    [SerializeField] private float cameraCollisionRadius = 0.2f;
    [SerializeField] private float cameraCollisionOffset = 0.2f; //how much the camera will jump off of collisions
    [SerializeField] private float minimumCollisionOffSet = 0.2f;
    private Vector3 cameraVectorPosition;
    public LayerMask collisionLayers; //layers we want our camera to collied with

    //vars for rotate speed of camera
    [Header("SENSITIVITY")]
    [SerializeField] private float cameraLookSpeed = 2f;
    [SerializeField] private float cameraPivotSpeed = 2f;

    //vars to limit how high/low you can rotate camera
    [Header("LOOK ANGLE")]
    [SerializeField] private float minimumPivotAngle = -35f;
    [SerializeField] private float maximumPiviotAngle = 35f;

    //On awake: sets all managers, transforms, and any other things that need to be set
    private void Awake()
    {
        inputManager = FindObjectOfType<InputManager>();
        targetTransform = FindObjectOfType<PlayerManager>().transform;
        cameraTransform = Camera.main.transform;
        defaultPosition = cameraTransform.localPosition.z;
    }
    
    /// <summary>
    /// Calls all functions to move camera
    /// </summary>
    public void HandleAllCameraMovement()
    {
        FollowTarget();
        RotateCamera();
        HandleCameraCollisions();
    }

    /// <summary>
    /// function for the camera to fallow the target(most likely player)
    /// </summary>
    private void FollowTarget()
    {
        Vector3 targetPos = Vector3.SmoothDamp(transform.position, targetTransform.position, ref cameraFollowVelocity, cameraFallowSpeed);
        
        transform.position = targetPos;
    }

    /// <summary>
    /// rotates the camera when moved
    /// </summary>
    private void RotateCamera()
    {
        Vector3 rotation;
        Quaternion targetRotation;

        lookAngle = lookAngle + (inputManager.CameraInputX * cameraLookSpeed);
        pivotAngle = pivotAngle + (inputManager.CameraInputY * cameraPivotSpeed);
        pivotAngle = Mathf.Clamp(pivotAngle, minimumPivotAngle, maximumPiviotAngle);

        rotation = Vector3.zero;
        rotation.y = lookAngle;
        targetRotation = Quaternion.Euler(rotation);
        transform.rotation = targetRotation;

        rotation = Vector3.zero;
        rotation.x = pivotAngle;
        targetRotation = Quaternion.Euler(rotation);
        cameraPivot.localRotation = targetRotation;
    }

    /// <summary>
    /// handles when camera collides with an object
    /// </summary>
    private void HandleCameraCollisions()
    {
        float targetPosition = defaultPosition;
        RaycastHit hit;
        Vector3 direction = cameraTransform.position - cameraPivot.position;
        direction.Normalize();

        if (Physics.SphereCast(cameraPivot.transform.position, cameraCollisionRadius, direction, out hit, Mathf.Abs(targetPosition), collisionLayers))
        {
            float distance = Vector3.Distance(cameraPivot.position, hit.point);
            targetPosition =- (distance - cameraCollisionOffset);
        }

        if (Mathf.Abs(targetPosition) < minimumCollisionOffSet)
        {
            targetPosition = targetPosition - minimumCollisionOffSet;
        }

        cameraVectorPosition.z = Mathf.Lerp(cameraTransform.localPosition.z, targetPosition, 0.2f);
        cameraTransform.localPosition = cameraVectorPosition;
    }
}
