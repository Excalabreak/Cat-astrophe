using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Dog : MonoBehaviour
{
    //Variable for enemy movement
    [SerializeField] float moveSpeed = 4;
    [SerializeField] AudioSource bark;
    [SerializeField] float minDist = 0;
    [SerializeField] Transform cat;
    [SerializeField] bool sighted;

    // Awake is called before the first frame update
    void Awake()
    {
        //Transforming sighted into false on awake
        sighted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (sighted == true)
        {
            CatFound();
        }
       
    }

    // Functions for moving dog
    //First encounter
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == cat)
        {
            bark.Play();
        }
    }

    //Sighted
    private void OnTriggerStay(Collider other)
    {
       //CatFound();

        if (other.transform == cat)
        {
            sighted = true;
            //bark.Play();
        }
    }

    //Not sighted
    private void OnTriggerExit(Collider other)
    {
        if(other.transform == cat)
        {
            sighted = false;
            bark.Stop();
        }
    }

    //Move
    private void CatFound()
    {
        Vector3 lookingCat = cat.transform.position;
        lookingCat.y = transform.position.y;
        transform.LookAt(lookingCat);
        if (Vector3.Distance(transform.position, cat.transform.position) >= minDist)
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
    }
}
