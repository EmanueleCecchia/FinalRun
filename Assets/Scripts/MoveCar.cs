using UnityEngine;

public class MoveCar : MonoBehaviour
{
    public float speed = 15f;
    public float maxSpeed = 20.0f; // Maximum speed limit
    public float distanceStartBreaking = 5.0f; // Minimum distance to maintain with the car in front
    public float maxBreakForce = 10.0f; // Maximum force to apply when breaking
    public float minBreakForce = 1.0f; // Minimum force to apply when breaking
    public float raycastOffsetY = 1.2f; // Offset for the raycast origin
    public enum Direction
    {
        Forward,
        Backward
    }
    public Direction direction = Direction.Forward;

    private Rigidbody rb;
    private bool canMove = true;
    private GameObject frontCar; // Reference to the car in front

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null) Debug.LogError("Rigidbody not found");

        // Find the car in front
        RaycastHit hit;
        Vector3 raycastOrigin = transform.position + Vector3.up * raycastOffsetY;
        if (Physics.Raycast( raycastOrigin, transform.forward, out hit, Mathf.Infinity))
        {
            //Debug.Log("Raycast hit: " + hit.collider.name);
            if (hit.collider.CompareTag("Car") && hit.collider.gameObject != gameObject)
            {
                frontCar = hit.collider.gameObject;
                Debug.Log("Front car found: " + frontCar.name);
            }
        }
    }

    void FixedUpdate()
    {
        if (rb != null && canMove)
        {
            Vector3 movementDirection = (direction == Direction.Forward) ? transform.forward : -transform.forward;
            Vector3 desiredVelocity = movementDirection * speed;
            Vector3 velocityChange = desiredVelocity - rb.velocity;

            rb.AddForce(velocityChange, ForceMode.VelocityChange);
        }

        // Check the distance to the car in front
        if (frontCar != null)
        {
            float distanceToCar = Vector3.Distance(transform.position, frontCar.transform.position);
            if (distanceToCar < distanceStartBreaking)
            {
                // Calculate braking force based on distance
                float breakForce = Mathf.Lerp(maxBreakForce, minBreakForce, distanceToCar / distanceStartBreaking);
                speed = Mathf.Clamp(speed - breakForce, 0f, speed); // Adjust this value for a faster/slower decrease in speed
            }
            else
            {
                // Increase the speed to the original speed
                speed = Mathf.Clamp(speed + 0.1f, 0f, maxSpeed); // Clamp speed to the maximum speed limit
            }
        }

        // Draw a debug line to visualize where the raycast is pointing
        Debug.DrawRay(transform.position + Vector3.up * raycastOffsetY, transform.forward * 10f, Color.blue);

    }
}
