using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoapScript : MonoBehaviour
{
    //on trigger, call to handle power up and destroy game object after
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
