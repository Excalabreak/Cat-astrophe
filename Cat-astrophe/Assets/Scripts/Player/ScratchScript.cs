using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScratchScript : MonoBehaviour
{
    [SerializeField] private GameObject scratchCollider;
    private MeshRenderer scratchMR;

    [SerializeField] private int scratchStrength = 1;
    
    private bool isScratching = false;

    private void Awake()
    {
        scratchMR = scratchCollider.GetComponent<MeshRenderer>();
    }

    //turns isScratching on
    public void HandleScratch()
    {
        StartCoroutine(Scratch());
    }

    //will scrach objects tagged with breakable
    private void OnTriggerStay(Collider other)
    {
        if (isScratching && other.gameObject.tag == "Breakable")
        {
            BreakableScript breakScript = other.gameObject.GetComponent<BreakableScript>();

            isScratching = false;

            if (!breakScript.Invincible)
            {
                breakScript.DamageObject(scratchStrength);
            }

            scratchMR.enabled = false;
        }
    }

    private IEnumerator Scratch()
    {
        //Debug.Log("hi");
        scratchMR.enabled = true;
        isScratching = true;

        yield return new WaitForSeconds(.5f);

        scratchMR.enabled = false;
        isScratching = false;
    }
}
