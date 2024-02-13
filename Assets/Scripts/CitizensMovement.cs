using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CitizensMovement : MonoBehaviour
{
    private NavMeshAgent myNavMeshAgent;
    private Animator myAnimator;

    public float walkSpeed = 1.6f;
    public float maxRadius = 70f;

    private Vector3 targetPosition;

    void Start()
    {
        myNavMeshAgent = GetComponent<NavMeshAgent>();
        myAnimator = GetComponent<Animator>();

        SetRandomDestination();
    }

    void Update()
    {
        if (!myNavMeshAgent.pathPending && myNavMeshAgent.remainingDistance < myNavMeshAgent.stoppingDistance)
        {
            SetRandomDestination();
        }

        myAnimator.SetFloat("Speed", myNavMeshAgent.velocity.magnitude);
    }

    void SetRandomDestination()
    {
        Vector3 randomDirection = Random.insideUnitSphere * maxRadius;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, maxRadius, 1);
        targetPosition = hit.position;
        myNavMeshAgent.SetDestination(targetPosition);   
    }

    void OnDrawGizmosSelected()
    {
        // draw the wanderRadius in the editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, maxRadius);
    }
}