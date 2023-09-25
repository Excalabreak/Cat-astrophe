using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupHoldToss : MonoBehaviour
{
    public GameObject ch1, ch2; //crosshair appears when looking at the object
    public Transform objT, cT; //object's and player camera's transform
    public bool interactable, pickup; //determines whether/not player is looking at the object & /not the object is picked up
    public Rigidbody _rb;
    public float throwAmount; //the distance the object can be thrown

    //if the player's camera is looking at the object, crosshair will change and interactabl=true
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("cat"))
        {
            ch1.SetActive(false);
            ch2.SetActive(true);
            interactable = true;
        }
    }
    //if the player's camera does the opposite
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("cat"))
        {
            if (pickup == false)
            {
                ch1.SetActive(true);
                ch2.SetActive(false);
                interactable = false;
            }
        }
    }
    private void Update()
    {
        //check if the player can pickup/not
        if(interactable == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                objT.parent = cT;
                _rb.useGravity = false;
                pickup = true;
            }
            if (Input.GetMouseButtonUp(0))
            {
                objT.parent = null;
                _rb.useGravity = true;
                pickup = false;
            }
            //object can be thrown
            if (pickup == true)
            {
                if (Input.GetMouseButtonDown(1))
                {
                    objT.parent = null;
                    _rb.useGravity = true;
                    _rb.velocity = cT.forward * throwAmount * Time.deltaTime;
                    pickup = false;
                }
            }
        }
    }
}
