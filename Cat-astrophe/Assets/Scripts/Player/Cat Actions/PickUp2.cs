using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp2 : MonoBehaviour
{
    [SerializeField] private LayerMask pickUpMask;
    [SerializeField] private Transform pickUpTarget;
    [SerializeField] private Transform orientation;

    [SerializeField] private float pickUpRange;
    private GameObject CurrentObject;
    private Rigidbody CurrentObjectRigidBody;
    private Collider CurrentObjectCollider;

    [SerializeField] private float throwForce = 5f;

    public void HandleToss()
    {
        if (CurrentObject)
        {
            CurrentObjectRigidBody.useGravity = true;
            CurrentObjectCollider.enabled = true;

            Vector3 throwDirection = orientation.forward;
            throwDirection.Normalize();
            throwDirection = throwDirection * throwForce;
            CurrentObjectRigidBody.AddForce(throwDirection, ForceMode.Impulse);

            CurrentObject = null;
            CurrentObjectRigidBody = null;
            CurrentObjectCollider = null;

            return;
        }
    }

    public void HandlePickUp()
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

        //Ray CameraRay = playerCamera.ViewportPointToRay(new Vector3(.5f, .5f, 0f));
        if (Physics.SphereCast(transform.position, 1f, orientation.forward, out RaycastHit hit, pickUpRange, pickUpMask))
        {
            CurrentObject = hit.transform.gameObject;
            CurrentObjectRigidBody = CurrentObject.GetComponent<Rigidbody>();
            CurrentObjectCollider = CurrentObject.GetComponent<Collider>();

            CurrentObjectRigidBody.useGravity = false;
            CurrentObjectCollider.enabled = false;
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
