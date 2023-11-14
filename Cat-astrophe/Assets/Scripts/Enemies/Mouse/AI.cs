using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask Ground, Player;
    public int speed;

    //[SerializeField] private float displacementDist = 3f;

    //Patrolling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;
    

    ////Running Away
    public float timeBetweenRunningAway;
    bool alreadyRunAway;

    //States
    public float sightRange, runRange;
    public bool playerInSightRange, playerInAttackRange;

    AudioManager audioManager;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        audioManager.PlaySFX(audioManager.mouse);
    }

    private void Update()
    {
        //check for sight and escape
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, Player);
        playerInAttackRange = Physics.CheckSphere(transform.position, runRange, Player);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) Stare();
        if (playerInSightRange && playerInAttackRange) RunAway();

        //RunAway();
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet) agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

       //walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f) walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
       //calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, Ground)) walkPointSet = true;
    }
    
    private void RunAway()
    {
        //Vector3 normDir = (player.position - transform.position).normalized;

        //normDir = Quaternion.AngleAxis(Random.Range(0, 179), Vector3.up) * normDir;

        //agent.Move(transform.position - (normDir * displacementDist));

        Vector3 direction = transform.position - player.position;
        if (direction.sqrMagnitude<25f)
        {
            transform.Translate(direction.normalized * speed *Time.deltaTime, Space.World);
            transform.forward = direction.normalized;
        }
    }
    
    private void Stare()
    {
        //make sure to wait and escape
        agent.SetDestination(transform.position);

        transform.LookAt(player);
    }

   
}
