using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePowerUp : MonoBehaviour
{
    [SerializeField] protected float powerUpTime;

    protected virtual void OnTriggerEnter(Collider other)
    {
        
    }
}
