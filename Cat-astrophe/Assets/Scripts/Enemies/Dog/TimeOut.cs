using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeOut : MonoBehaviour
{
    //Variables for moving the cat and timer
    [SerializeField] Transform box;
    [SerializeField] Transform back;
    [SerializeField] Transform dogo;
    [SerializeField] Collider restricter;
    


    // On Trigger Enter detection of the cat
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(ToBox());
            other.transform.position = box.transform.position;
            dogo.transform.position = back.transform.position;
        }
    }

    // Making a timer for wating in box
    IEnumerator ToBox()
    {
        restricter.gameObject.SetActive(true);
        yield return new WaitForSeconds(5f);
        restricter.gameObject.SetActive(false);
    }
}
