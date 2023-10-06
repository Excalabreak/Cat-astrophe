using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objective : MonoBehaviour
{
    // Varibles
    public AudioSource objSFX;
    public GameObject theObjective;
    public GameObject theTrigger;
    public GameObject theText;


    // Trigger enter
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(missionObj());
        }

        // Action
         IEnumerator missionObj()
        {
            objSFX.Play();
            theObjective.SetActive(true);
            theObjective.GetComponent<Animation>().Play("ObjectiveDisplayAnim");
            theText.GetComponent<Text>().text = "Destroy everything before Clara gets back home!";

            // Delay function
            yield return new WaitForSeconds(7.3f);
            theText.GetComponent<Text>().text = "";
            theTrigger.SetActive(false);
            theObjective.SetActive(false);
        }
    }
}
