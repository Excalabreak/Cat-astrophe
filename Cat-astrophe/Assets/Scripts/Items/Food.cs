using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Food : MonoBehaviour, IUsable
{
    public UnityEvent OnUse => throw new System.NotImplementedException();

    private int energyBoost = 1;

    public void Use(GameObject actor)
    {
        actor.GetComponent<Pickup>().AddBoost(energyBoost);
        Destroy(gameObject);
    }

    
}
