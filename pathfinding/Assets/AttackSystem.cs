using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSystem : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange;
    public ParticleSystem attackParticles;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Collider enemyCollider = DetectEnemy();

            if (enemyCollider != null)
            {
                attackParticles.transform.position = enemyCollider.transform.position;
                attackParticles.Play();
                Destroy(enemyCollider.gameObject);
            }
        }
    }

    Collider DetectEnemy()
    {
        Collider[] colls = Physics.OverlapSphere(attackPoint.position, attackRange);
        if (colls.Length != 0)
        {
            for (int i = 0; i < colls.Length; i++)
            {
                if (colls[i].gameObject.TryGetComponent(out EnemyMovement enemy))
                {
                    return colls[i];
                }
            }
            return null;
        }
        return null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(attackPoint.position, attackRange);
    }
}
