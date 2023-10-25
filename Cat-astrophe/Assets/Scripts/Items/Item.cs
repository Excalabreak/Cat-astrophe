using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            ScoreManager.instance.AddPoint();
            Destroy(this.gameObject);
           
        }
    }
}
