using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerControls pControls;

    private float speed = 5f;

    //On awake, this make sure that a PlayerControls is there and enabled
    private void Awake()
    {
        if (pControls == null)
        {
            pControls = new PlayerControls();
        }
        pControls.Enable();
    }

    //runs every frame to update input information
    private void Update()
    {
        Move();
    }

    //reads the inputs and moves
    private void Move()
    {
        Vector2 moveInput = pControls.PlayerMovement.Movement.ReadValue<Vector2>();
        transform.position += new Vector3(moveInput.x * speed * Time.deltaTime, 0, moveInput.y * speed * Time.deltaTime);
    }
}
