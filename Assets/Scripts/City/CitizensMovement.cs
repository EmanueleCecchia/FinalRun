using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CitizensMovement : MonoBehaviour
{
    private NavMeshAgent myNavMeshAgent;
    private Animator myAnimator;

    public float walkSpeed = 1.5f;
    public float minDistance = 2f;
    public float wanderRadius = 10f; // Maximum range for the random destination

    private Vector3 targetPosition; // The position the NPC is currently moving towards

    void Start()
    {
        myNavMeshAgent = GetComponent<NavMeshAgent>();
        myAnimator = GetComponent<Animator>();

        SetRandomDestination();
    }

    void Update()
    {
        // If the NPC has reached its destination or is very close, set a new random destination
        if (!myNavMeshAgent.pathPending && myNavMeshAgent.remainingDistance < minDistance)
        {
            SetRandomDestination();
        }

        // Update animator parameters if you have animations based on movement
        myAnimator.SetFloat("Speed", myNavMeshAgent.velocity.magnitude / myNavMeshAgent.speed);
    }

    void SetRandomDestination()
    {
        // Get a random point in the NavMesh within wanderRadius distance from the NPC's current position
        Vector3 randomDirection = Random.insideUnitSphere * wanderRadius;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, wanderRadius, 1);
        targetPosition = hit.position;

        // Set the new destination for the NavMeshAgent
        myNavMeshAgent.SetDestination(targetPosition);
    }
}


//SetRandomDestination();
//myNavMeshAgent.speed = walkSpeed;

/*
void Update()
{
    if (myNavMeshAgent.remainingDistance < recalculateDistance)
    {
        SetRandomDestination();
    }

    myAnimator.SetFloat("Speed", myNavMeshAgent.velocity.magnitude);
}

public void SetRandomDestination()
{
    Vector3 randomDirection = new Vector3(Random.Range(-rangeRandomPointXZ, rangeRandomPointXZ), Random.Range(-rangeRandomPointY, rangeRandomPointY), Random.Range(-rangeRandomPointXZ, rangeRandomPointXZ));
    randomDirection += transform.position;

    NavMeshHit hit;
    Vector3 finalPosition = Vector3.zero;

    while (finalPosition == Vector3.zero || Vector3.Distance(transform.position, finalPosition) < minDistance)
    {
        NavMesh.SamplePosition(randomDirection, out hit, rangeRandomPointXZ, 1);
        finalPosition = hit.position;
    }

    myNavMeshAgent.SetDestination(finalPosition);
}
*/