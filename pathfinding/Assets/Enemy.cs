using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Vector3 p1, p2;
    public float radius;
    public float speed;
    Vector3 currentTarget;




    public State currentState = State.Idle;

    // Start is called before the first frame update
    void Start()
    {
        p1 = (Vector2)transform.position + new Vector2(Random.Range(0f, radius), Random.Range(0f, radius));
        p2 = (Vector2)transform.position + new Vector2(Random.Range(0f, radius), Random.Range(0f, radius));

        currentTarget = p1;
    }

   
    void FixedUpdate()
    {
        if (currentState == State.Idle)
        {
            if (transform.position != currentTarget)
            {
                transform.position = Vector2.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime );
            }
            else
            {
                if (currentTarget == p1)
                {
                    currentTarget = p2;
                    p1 = (Vector3)transform.position + new Vector3(Random.Range(0f, radius), Random.Range(0f, radius));
                }
                else
                {
                    currentTarget = p1;
                    p2 = (Vector2)transform.position + new Vector2(Random.Range(0f, radius), Random.Range(0f, radius));
                }
            }
        }

        if (currentState == State.Chasing)
        {

        }
    }


    public enum State
    {
        Idle,
        Chasing
    }
}
