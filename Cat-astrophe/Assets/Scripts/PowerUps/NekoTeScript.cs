using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NekoTeScript : MonoBehaviour
{
    //IDEA TO REMEMGER: REMOVE NEKOTE, REDUCE TIME AND/OR CONE OF SHAME AFTER DESTROYING CAMERA
    //GIVES DILEMA OF DESTROYING CAMERAS OR BLOCKING THEM
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<ScratchScript>().PickUpNekoTe();
            Destroy(this.gameObject);
        }
    }
}
