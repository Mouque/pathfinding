using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform point1, point2;
    public NavMeshAgent agent;
    private Transform currentTarget;

    // Start is called before the first frame update
    void Start()
    {
        currentTarget = point1;
        agent.SetDestination(currentTarget.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            if (currentTarget == point1)
            {
                currentTarget = point2;
            }
            else
            {
                currentTarget = point1;
            }
            agent.SetDestination(currentTarget.position);
        }
    }
}
