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
        if ((transform.position - agent.destination).magnitude <= agent.stoppingDistance)
        {
            if ((transform.position - point1.position).magnitude < (transform.position - point2.position).magnitude)
            {
                agent.SetDestination(point2.position);
            }
            else
            {
                agent.SetDestination(point1.position);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            if (other.TryGetComponent(out PlayerController player))
            {
                player.GoToSpawnPoint();
            }
        }
    }
}
