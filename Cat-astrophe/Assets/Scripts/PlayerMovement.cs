using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    public float maxSpeed;
    public float rotationSpeed;
    public float maxJump;
    public float jumpGracePeriod;

    [SerializeField]
    private CharacterController characterController;
    private float ySpeed;
    private float originalStepOffset;
    //? represent its nulliable 
    private float? lastGroundedTime;
    private float? jumpPressedTime;

    [SerializeField]
    private Transform cameraTransform;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        originalStepOffset = characterController.stepOffset;
    }

    // Update is called once per frame
    void Update()
    {
        //movement
        float horizontialInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontialInput, 0, verticalInput);

        //helps with gamepad force
        //float magnitude = moveDirection.magnitude;
         //magnitude = Mathf.Clamp01(magnitude);
        float inputMagnitude = Mathf.Clamp01(moveDirection.magnitude);

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            inputMagnitude /= 2;
        }

        float speed = inputMagnitude * maxSpeed;

        //camera
        moveDirection = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * moveDirection;

        //nomailize converts the magnitude vector into 1
        moveDirection.Normalize();

        //Vector3 velocity = moveDirection * magnitude;
        Vector3 velocity = moveDirection * speed;
        velocity.y = ySpeed;
        //transform.Translate(moveDirection * maxSpeed * Time.deltaTime, Space.World);
        characterController.Move(velocity * Time.deltaTime);

        //rotation
        if (moveDirection != Vector3.zero)
        {
            //transform.forward = moveDirection;
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        //jump
        ySpeed += Physics.gravity.y * Time.deltaTime;

        if (characterController.isGrounded)
        {
            lastGroundedTime = Time.time;
        }

        if (Input.GetButtonDown("Jump"))
        {
            jumpPressedTime = Time.time;
        }

        if (Time.time - lastGroundedTime <= jumpGracePeriod)
        {
            characterController.stepOffset = originalStepOffset;
            ySpeed = -0.5f;

            if (Time.time - jumpPressedTime <= jumpGracePeriod)
            {
                ySpeed = maxJump;
                jumpPressedTime = null;
                lastGroundedTime = null;
            }
        }
        else
        {
            characterController.stepOffset = 0;
        }
    }

    //mouse cursor is inactive in game
    private void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}


