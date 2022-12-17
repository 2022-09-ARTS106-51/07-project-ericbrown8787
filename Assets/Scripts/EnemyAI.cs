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
    public float pursuitDistance = 6;
    private float distanceFromPlayer;
    Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //anim = GetComponent<Animation>();
        //foreach (AnimationState state in anim)
        //{
        //    state.speed = 0.5F;
        //}
        UpdateDestination();
    }

    // Update is called once per frame
    void Update()
    {
        distanceFromPlayer = Vector3.Distance(agent.transform.position, playerTransform.position);
        Debug.Log(distanceFromPlayer);

        if (distanceFromPlayer <= pursuitDistance)
        {
            Debug.Log("You got close enough to die!");
            agent.destination = playerTransform.position;
        }
        else {
            if (Vector3.Distance(transform.position, target) < 1)
            {
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

    void IterateWaypointIndex()
    {
        //waypointIndex++;
        //if (waypointIndex == waypoints.Length)
        //{
        //    waypointIndex = 0;
        //}
        waypointIndex = Random.Range(0,waypoints.Length);
    }
}
