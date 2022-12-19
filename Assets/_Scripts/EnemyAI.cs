using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform playerTransform;
    NavMeshAgent agent;
    public Transform[] waypoints;
    int waypointIndex;
    public float walkSpeed;
    public float runSpeed;
    public float pursuitDistance = 6;
    private float distanceFromPlayer;
    Vector3 target;
    private Animator animator;

    void Start()
    {   
        agent = GetComponent<NavMeshAgent>();
        animator= GetComponent<Animator>();
        IterateWaypointIndex();
        UpdateDestination();
        SetWalking();
    }

    // Update is called once per frame
    void Update()
    {
        distanceFromPlayer = Vector3.Distance(agent.transform.position, playerTransform.position);

        if (distanceFromPlayer <= pursuitDistance)
        {
            SetRunning();
            agent.destination = playerTransform.position;
         }
        else {
            if (animator.GetBool("isWalking") != true)
            { 
                SetWalking();
            }
        
            if (Vector3.Distance(transform.position, target) < 1)
            {
                SetWalking();
                IterateWaypointIndex();
                UpdateDestination();
            }
        }
    }

    void UpdateDestination()
    {
        target = waypoints[waypointIndex].position;
        agent.SetDestination(target);
    }

    void SetWalking() { 
        animator.SetBool("isIdle", false);
        animator.SetBool("isRunning", false);
        animator.SetBool("isWalking", true) ;
        agent.speed = walkSpeed;
    }

    void SetIdle()
    {
        animator.SetBool("isIdle", true);
        animator.SetBool("isRunning", false);
        animator.SetBool("isWalking", false);
        agent.speed = 0;
    }

    void SetRunning()
    {
        animator.SetBool("isIdle", false);
        animator.SetBool("isRunning", true);
        animator.SetBool("isWalking", false);
        agent.speed = runSpeed ;
    }
    void IterateWaypointIndex()
    {
        waypointIndex = Random.Range(0,waypoints.Length);
    }
}
