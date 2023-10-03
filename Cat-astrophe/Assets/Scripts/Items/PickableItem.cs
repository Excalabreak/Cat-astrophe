using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableItem : MonoBehaviour, IPickable
{
    [field: SerializeField]
    public bool KeepWorldPosition { get; private set; }

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public GameObject PickUp()
    {
        if(rb != null)
        {
            rb.isKinematic = true;
        }
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
        return gameObject;
    }
}
