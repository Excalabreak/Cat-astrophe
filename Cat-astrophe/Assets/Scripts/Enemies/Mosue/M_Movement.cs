using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MController : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject player;

    [SerializeField] LayerMask groundLayer, playerLayer;

    //move distance
    public Vector3 distPoint;
    public bool walkpointSet;

    [SerializeField] float range;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        MoveDist();
    }

    private void MoveDist()
    {
        if (!walkpointSet)
        {
            SearchForDist();
        }
        if (walkpointSet)
        {
            agent.SetDestination(distPoint);
        }
        if (Vector3.Distance(transform.position, distPoint)<30)
        {
            walkpointSet = false;
        }
    }

    private void SearchForDist()
    {
        float z = Random.Range(-range, range);
        float x = Random.Range(-range, range);

        distPoint = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);

        if (Physics.Raycast(distPoint, Vector3.down, groundLayer))
        {
            walkpointSet = true;
        }
    }


}
