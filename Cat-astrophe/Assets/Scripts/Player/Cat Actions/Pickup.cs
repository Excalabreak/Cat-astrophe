using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pickup : MonoBehaviour
{
    [SerializeField]
    private LayerMask pickableLayerMask;

    [SerializeField]
    private Transform playerCameraTransform;

    [SerializeField]
    private GameObject pickUpUI;

    internal void AddBoost(int energyBoost)
    {
        Debug.Log($"Energy boosted by {energyBoost}");
    }

    [SerializeField]
    //helps not to go into negative value
    [Min(1)]
    private float hitRange = 3;

    [SerializeField]
    private Transform pickUpParent;

    [SerializeField]
    private GameObject inHandItem;

    [SerializeField]
    private float throwForce = 700; 

    [SerializeField]
    private InputActionReference interactionInput, dropInput, useInput, useToss;

    private RaycastHit hit;

    [SerializeField]
    private AudioSource pickUpSource;

    [SerializeField] private Transform InHandTransform;

    private void Start()
    {
        //change Interact to PickUp
        interactionInput.action.performed += PickUp;
        dropInput.action.performed += Drop;
        useInput.action.performed+= Use;
        useToss.action.performed += Toss;
    }

    private void Toss(InputAction.CallbackContext obj)
    {
        inHandItem.GetComponent<Rigidbody>().isKinematic = false;
        inHandItem.GetComponent<Rigidbody>().AddForce(transform.forward * throwForce);
        inHandItem.transform.SetParent(null);
        inHandItem = null;
    }

    private void Use(InputAction.CallbackContext obj)
    {
        if (inHandItem != null)
        {
            IUsable usable = inHandItem.GetComponent<IUsable>();
            if (usable != null)
            {
                usable.Use(this.gameObject);
            }
        }
    }

    private void Drop(InputAction.CallbackContext obj)
    {
        if (inHandItem != null)
        {
            inHandItem.transform.SetParent(null);
            inHandItem = null;
            Rigidbody rb = hit.collider.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false;
            }
        }
    }

    //change Interact to PickUp
    private void PickUp(InputAction.CallbackContext obj)
    {
        if (hit.collider != null && inHandItem == null)
        {
            IPickable pickableItem = hit.collider.GetComponent<IPickable>();
            if (pickableItem != null)
            {
                pickUpSource.Play();
                inHandItem = pickableItem.PickUp();
                inHandItem.transform.position = InHandTransform.position;
                inHandItem.transform.SetParent(pickUpParent.transform, pickableItem.KeepWorldPosition);
            }
            //Debug.Log(hit.collider.name);
            //Rigidbody rb = hit.collider.GetComponent<Rigidbody>();
            ////keep weapon for right now unitl later upgrade
            //if (hit.collider.GetComponent<Food>() || hit.collider.GetComponent<Weapon>())
            //{
            //    Debug.Log("It's Food!");
            //    inHandItem = hit.collider.gameObject;
            //    inHandItem.transform.position = Vector3.zero;
            //    inHandItem.transform.rotation = Quaternion.identity;
            //    inHandItem.transform.SetParent(pickUpParent.transform, false);
            //    if (rb != null)
            //    {
            //        rb.isKinematic = true;
            //    }
            //    return;
            //}
            //if (hit.collider.GetComponent<Item>())
            //{
            //    Debug.Log("It's a USELESS item!");
            //    inHandItem = hit.collider.gameObject;
            //    inHandItem.transform.SetParent(pickUpParent.transform, true);
            //    if (rb != null)
            //    {
            //        rb.isKinematic = true;
            //    }
            //    return;
            //}
        }
    }

    private void Update()
    {
        //Debug.DrawRay(playerCameraTransform.position, playerCameraTransform.forward * hitRange, Color.red);
        if (hit.collider != null)
        {
            //? = check if is active or not
            //hit.collider.GetComponent<Highlight>()?.ToggleHighlight(false);
            pickUpUI.SetActive(false);
        }

        if (inHandItem != null)
        {
            return;
        }

        if (Physics.Raycast(playerCameraTransform.position,playerCameraTransform.forward,out hit, hitRange, pickableLayerMask))
        {
            //hit.collider.GetComponent<Highlight>()?.ToggleHighlight(true);
            pickUpUI.SetActive(true);
        }

        
    }
}
