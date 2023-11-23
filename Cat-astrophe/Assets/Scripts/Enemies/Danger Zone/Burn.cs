using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Burn : MonoBehaviour
{
    // Variables for changing the player position 
    [SerializeField] GameObject backing;

    // OnTrigger enter whe cat is burned
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //StartCoroutine(Burnt());
            other.transform.position = backing.transform.position;
            ConeOfShame cos = other.GetComponent<ConeOfShame>();
            if (cos.HasConeOfShame)
            {
                cos.OnGameOver();
            }
            else if (cos.FirstWarning)
            {
                cos.AddConeOfShame();
            }
            else
            {
                cos.GiveFirstWarning();
            }
            
        }
    }

 
}
