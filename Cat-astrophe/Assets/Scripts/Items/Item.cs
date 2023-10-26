using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Environment")
        {
            ScoreManager.scoreCount +=1 ;
            Destroy(this.gameObject);
        }
    }
}
