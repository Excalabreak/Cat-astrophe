using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NekoTeScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<ScratchScript>().PickUpNekoTe();
            Destroy(this.gameObject);
        }
    }
}
