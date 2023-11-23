using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoapScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ConeOfShame cos = other.GetComponent<ConeOfShame>();
            if (cos.HasConeOfShame)
            {
                cos.ResetConeOfShame();
                Destroy(this.gameObject);
            }
            
        }
    }
}
