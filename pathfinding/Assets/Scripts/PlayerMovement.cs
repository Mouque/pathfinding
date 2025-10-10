using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public Transform spawnPoint;

    float xDir;
    float zDir;
    Vector3 moveDirection;

    public float speed;
    public float deceleration;


    // Update is called once per frame
    void Update()
    {
        MyInput();
        SpeedControl();
    }

    private void FixedUpdate()
    {
        rb.AddForce( moveDirection.normalized * speed, ForceMode.Force );

        if ( moveDirection.magnitude == 0f )
        {
            rb.velocity = Vector3.MoveTowards( rb.velocity, Vector3.zero, deceleration * Time.deltaTime );
            // change animation to idle
        
        }

        if (moveDirection.magnitude != 0f)
        {
            // change animation to run
        }
    }

    void MyInput()
    {
        xDir = Input.GetAxisRaw( "Horizontal" );
        zDir = Input.GetAxisRaw( "Vertical" );

        moveDirection = new Vector3( xDir, 0f, zDir );
    }

    void SpeedControl()
    {
        Vector3 flatVelocity = new Vector3( rb.velocity.x, 0f, rb.velocity.z );

        if ( flatVelocity.magnitude > speed )
        {
            Vector3 limitedVel = flatVelocity.normalized * speed;
            rb.velocity = new Vector3( limitedVel.x, rb.velocity.y, limitedVel.z );
        }

    }

    public void GoToSpawnPoint()
    {
        transform.position = 
            new Vector3( spawnPoint.position.x, transform.position.y, spawnPoint.position.z );

    }
}
