using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMousePosition : MonoBehaviour
{
    public Transform playerTransform;
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerScreenPosition = cam.WorldToScreenPoint(playerTransform.position);

        Vector3 lookDirection = (Input.mousePosition - playerScreenPosition).normalized;

        transform.position =
            new Vector3(
                playerTransform.position.x + lookDirection.x,
                playerTransform.position.y,
                playerTransform.position.z + lookDirection.y);


        Vector3 lookTowards = (transform.position - playerTransform.position).normalized;

        transform.rotation = Quaternion.LookRotation(lookTowards);
    }
}
