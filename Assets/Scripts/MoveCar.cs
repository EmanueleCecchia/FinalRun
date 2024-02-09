using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCar : MonoBehaviour
{

    public float speed = 10.0f;
    public enum Direction
    {
        Forward,
        Backward
    }
    public Direction direction = Direction.Forward;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null) Debug.LogError("Rigidbody not found");
    }

    void FixedUpdate()
    {
        if (rb != null)
        {
            Vector3 movementDirection = (direction == Direction.Forward) ? transform.forward : -transform.forward;
            Vector3 desiredVelocity = movementDirection * speed;
            Vector3 velocityChange = desiredVelocity - rb.velocity;

            rb.AddForce(velocityChange, ForceMode.VelocityChange);
        }
    }
}
