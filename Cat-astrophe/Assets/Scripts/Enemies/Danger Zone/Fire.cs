using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Fire : MonoBehaviour
{
    // Variables for objects
    [SerializeField] GameObject fire;

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(FireOn());
        }
    }

    // Function for activating fire
    private IEnumerator FireOn()
    {
        fire.SetActive(true);
        yield return new WaitForSeconds(5f);
        StartCoroutine(FireOut());

    }

    // Function for fire out
    private IEnumerator FireOut()
    {
        fire.SetActive(false);
        yield return new WaitForSeconds(30f);
        StartCoroutine(FireOn());
    }

}
