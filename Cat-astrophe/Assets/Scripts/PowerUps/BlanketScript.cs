using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlanketScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerDetected>().HandleBlanket();
            Destroy(this.gameObject);
        }
    }
}
