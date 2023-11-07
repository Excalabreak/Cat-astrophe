using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour, Interactiable
{
    // Serialized fields
    [SerializeField] private string prompt;


    // Interface
    public string interactionPromp => prompt;

    public bool Interact(Interactor iInteractor)
    {
        //Debug.Log("Damage!");
        return true;
    }
}
