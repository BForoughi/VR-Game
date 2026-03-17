using UnityEngine;
using System.Collections.Generic;

public class RobotControllerTwo : MonoBehaviour
{
    public Rigidbody RB;
    public Transform cameraTransform;

    public float speed = 6f;
    public float rotationSpeed = 12f;

    public float multiplier;
    public bool move;





    void Update()
    {
      

        // movement input
        if (Input.GetKeyDown(KeyCode.W))
            move = true;

        if (Input.GetKeyUp(KeyCode.W))
            move = false;

        if (move)
            multiplier = Mathf.Lerp(multiplier, 1, Time.deltaTime * 5f);
        else
            multiplier = 0;
    }

    void FixedUpdate()
    {
        Vector3 camForward = cameraTransform.forward;
        camForward.y = 0;
        camForward.Normalize();

        Vector3 moveDir = camForward;

        RB.linearVelocity = moveDir * speed * multiplier;

        if (RB.linearVelocity.magnitude > 0.01f)
        {
            if (moveDir.magnitude > 0.1f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(moveDir);
                transform.rotation = Quaternion.Slerp(
                    transform.rotation,
                    targetRotation,
                    rotationSpeed * Time.deltaTime
                );
            }
        }
    }
}