using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Dog : MonoBehaviour
{
    //Variable for enemy movement
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] AudioSource bark;
    [SerializeField] float minDist = 0;
    [SerializeField] bool sighted;

    private GameObject player;

    // Awake is called before the first frame update
    void Awake()
    {
        //Transforming sighted into false on awake
        sighted = false;
        player = GameObject.FindGameObjectWithTag("Player");
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
        if (other.transform.tag == "Player")
        {
            bark.Play();
        }
    }

    //Sighted
    private void OnTriggerStay(Collider other)
    {

        if (other.transform.tag == "Player" && !other.gameObject.GetComponent<PlayerDetected>().Blanket)
        {
            sighted = true;
        }
    }

    //Not sighted
    private void OnTriggerExit(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            sighted = false;
            bark.Stop();
        }
    }

    //Move
    private void CatFound()
    {
        Vector3 lookingCat = player.transform.position;
        lookingCat.y = transform.position.y;
        transform.LookAt(lookingCat);
        if (Vector3.Distance(transform.position, player.transform.position) >= minDist)
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
    }
}
