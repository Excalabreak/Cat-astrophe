using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 

public class Interactor : MonoBehaviour
{
    // Serialized fields for interactions (i)
    [SerializeField] private Transform iPoint;
    [SerializeField] private float iRadius = 0.5f;
    [SerializeField] private LayerMask iMask;

    // Private fields not need it for inspector
    private readonly Collider[] colliders = new Collider[3];
    private int numFound;

    // Variables for text
    private Interactiable inte;
    [SerializeField] private InteractionPromptUI iUI;

    // Working code
    private void Update()
    {
        numFound = Physics.OverlapSphereNonAlloc(iPoint.position, iRadius, colliders, iMask);

        if (numFound > 0)
        {
            inte = colliders[0].GetComponent<Interactiable>();

            if (inte != null)
            {
                if (!iUI.IsDisplayed) iUI.SetUp(inte.interactionPromp);

                if (Keyboard.current.eKey.wasPressedThisFrame) inte.Interact(this);

            }

        }
        else
        {
            if (inte != null) inte = null;
            if (iUI.IsDisplayed) iUI.Close();
        }
    }

}
