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
        if (other.transform == GameObject.FindGameObjectWithTag("Player").transform)
        {
            bark.Play();
        }
    }

    //Sighted
    private void OnTriggerStay(Collider other)
    {

        if (other.transform == GameObject.FindGameObjectWithTag("Player").transform)
        {
            sighted = true;
        }
    }

    //Not sighted
    private void OnTriggerExit(Collider other)
    {
        if(other.transform == GameObject.FindGameObjectWithTag("Player").transform)
        {
            sighted = false;
            bark.Stop();
        }
    }

    //Move
    private void CatFound()
    {
        Vector3 lookingCat = GameObject.FindGameObjectWithTag("Player").transform.position;
        lookingCat.y = transform.position.y;
        transform.LookAt(lookingCat);
        if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) >= minDist)
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
    }
}
