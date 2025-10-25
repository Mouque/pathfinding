using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float radius;
    [Range(0,360)]
    public float angle;

    public EnemyMovement enemyMovementScript;
    public GameObject playerRef;
    public ParticleSystem PlayerKillParticles;
    

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canSeePlayer;

    private void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        PlayerKillParticles = GameObject.FindGameObjectWithTag("PlayerKillParticles").GetComponent<ParticleSystem>();
        StartCoroutine(FOVRoutine());
    }

    private void Update()
    {
        if (canSeePlayer)
        {
            StartCoroutine(enemyMovementScript.PauseToKillPlayer(playerRef.transform.position));

            PlayPlayerKillParticles();

            playerRef.TryGetComponent(out PlayerMovement player);
            player.GoToSpawnPoint();
            canSeePlayer = false;
        }
    }

    void PlayPlayerKillParticles()
    {
        PlayerKillParticles.transform.position = playerRef.transform.position;
        PlayerKillParticles.transform.LookAt(-(new Vector3(transform.position.x, PlayerKillParticles.transform.position.y, transform.position.z)));
        PlayerKillParticles.Play();
    }

    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                    canSeePlayer = true;
                else
                    canSeePlayer = false;
            }
            else
                canSeePlayer = false;
        }
        else if (canSeePlayer)
            canSeePlayer = false;
    }
}
