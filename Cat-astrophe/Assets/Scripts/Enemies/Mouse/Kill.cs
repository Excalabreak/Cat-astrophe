using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Scratch")
        {
            ScoreManager.scoreCount += 8;
            Destroy(this.gameObject);
        }
    }
}
