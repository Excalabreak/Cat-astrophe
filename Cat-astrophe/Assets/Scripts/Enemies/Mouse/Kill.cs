using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour
{
    private void OnTriggerEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Scratch")
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Scratch")
        {
            Destroy(this.gameObject);
        }
    }
}
