using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] GameObject tutorialPer;
    [SerializeField] GameObject tutorialAni;
    [SerializeField] GameObject trigger;
    

    // Start is called before the first frame update
    void Start()
    {
       tutorialPer.SetActive(false);
       tutorialAni.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            tutorialPer.SetActive(true);
            tutorialAni.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            tutorialPer.SetActive(false);
            tutorialAni.SetActive(true);
            trigger.SetActive(false);
        }
    }
}
