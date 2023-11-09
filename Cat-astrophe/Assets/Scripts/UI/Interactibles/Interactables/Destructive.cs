using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Destructive : MonoBehaviour, Interactiable
{
    // Serialized fields
    [SerializeField] private string prompt;


    // Interface
    public string interactionPromp => prompt;

    public bool Interact(Interactor iInteractor)
    {
        //Debug.Log("Destroy");
        return true;
    }
}
