using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{

    public NavMeshAgent agent;
    public Camera cam;

    public Transform spawnPoint;


    private void Start()
    {
        GoToSpawnPoint();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }

        }

    }

    public void GoToSpawnPoint()
    {
        agent.SetDestination(spawnPoint.position);
        transform.position = 
            new(spawnPoint.position.x, transform.position.y, spawnPoint.position.z);
    }
}
