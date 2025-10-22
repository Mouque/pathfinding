using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Vector3 initialPosition;
    Vector3 p1, p2;
    public float radius;
    public float speed;
    Vector3 currentTarget;

    Vector3 moveDirection;

    Transform Player;
    public float viewRadius;



    public State currentState = State.Idle;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;

        initialPosition = transform.position;
        p1 = initialPosition + new Vector3(Random.Range(0f, radius), Random.Range(0f, radius));
        p2 = initialPosition + new Vector3(Random.Range(0f, radius), Random.Range(0f, radius));

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
                    p1 = initialPosition + new Vector3(Random.Range(0f, radius), Random.Range(0f, radius));
                }
                else
                {
                    currentTarget = p1;
                    p2 = initialPosition + new Vector3(Random.Range(0f, radius), Random.Range(0f, radius));
                }
            }

            print(Vector3.Distance(transform.position, Player.position));

            if (Vector3.Distance(transform.position, Player.position) < viewRadius)
            {
                OnChasingEnter();
            }


            moveDirection = (currentTarget - transform.position).normalized;

        }

        if (currentState == State.Chasing)
        {
            currentTarget = Player.position;

            transform.position = Vector2.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);



        }
    }

    void OnChasingEnter()
    {
        currentState = State.Chasing;
        print("mudei para o estado chasing");
    }


    public enum State
    {
        Idle,
        Chasing
    }
}
