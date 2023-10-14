using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cucumber : MonoBehaviour
{
    //Variable for player
    public Animator scaredAnim;

    //Animation on Triggeer
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           scaredAnim.SetBool("Scared", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            scaredAnim.SetBool("Scared", false);
        }
    }
}
