using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Interactiable
{
    // Interaction variables
    public string interactionPromp {  get; }
    public bool Interact (Interactor iInteractor);
}
