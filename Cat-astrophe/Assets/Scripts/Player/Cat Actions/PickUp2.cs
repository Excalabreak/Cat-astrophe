using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp2 : MonoBehaviour
{
    [SerializeField] private LayerMask pickUpMask;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private Transform pickUpTarget;

    [SerializeField] private float pickUpRange;
    [SerializeField] private GameObject CurrentObject;
    [SerializeField] private Rigidbody CurrentObjectRigidBody;
    [SerializeField] private Collider CurrentObjectCollider;

    private bool doPickUp = false;

    public void HandleToss()
    {

    }

    public void HandlePickUp()
    {
        doPickUp = !doPickUp;
    }

    private void Update()
    {
        if (doPickUp)
        {
            Ray CameraRay = playerCamera.ViewportPointToRay(new Vector3(.5f, .5f, 0f));
            if (Physics.Raycast(CameraRay, out RaycastHit hit, pickUpRange, pickUpMask))
            {
                CurrentObject = hit.transform.gameObject;
                CurrentObjectRigidBody = CurrentObject.GetComponent<Rigidbody>();
                CurrentObjectCollider = CurrentObject.GetComponent<Collider>();

                CurrentObjectRigidBody.useGravity = false;
                CurrentObjectCollider.enabled = false;
            }
        }
        else
        {
            if (CurrentObject)
            {
                CurrentObjectRigidBody.useGravity = true;
                CurrentObjectCollider.enabled = true;

                CurrentObject = null;
                CurrentObjectRigidBody = null;
                CurrentObjectCollider = null;

                return;
            }
        }
    }

    private void FixedUpdate()
    {
        if (CurrentObject)
        {
            Vector3 directionToPoint = pickUpTarget.position - CurrentObjectRigidBody.position;
            float distanceToPoint = directionToPoint.magnitude;

            CurrentObjectRigidBody.velocity = directionToPoint * 12f * distanceToPoint;
        }
    }
}
