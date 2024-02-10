using UnityEngine;

public class MoveCar : MonoBehaviour
{
    public float speed = 15f;
    public float acceleration = 0.2f;
    public float maxSpeed = 20.0f;
    public float distanceStartBreaking = 5.0f;
    public float maxBrakeForce = 10.0f;
    public float minBrakeForce = 1.0f;
    public float raycastOffsetY = 1.2f;
    public enum Direction
    {
        Forward,
        Backward
    }
    public Direction direction = Direction.Forward;

    private Rigidbody rb;
    private GameObject frontObject; // can be like a car or a traffic signal
    private Vector3 movementDirection;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null) Debug.LogError("Rigidbody not found");

        movementDirection = (direction == Direction.Forward) ? transform.forward : -transform.forward;
    }

    void FixedUpdate()
    {
        FindObjectInFront();

        if (rb != null)
        {
            ApplyForceToTheCar();
        }

        if (frontObject != null)
        {
            RegulateSpeed();
        } 
        else
        {
            AccelerateCar();
        }

        Debug.DrawRay(transform.position + Vector3.up * raycastOffsetY, transform.forward * 10f, Color.blue);
    }

    private void FindObjectInFront()
    {
        RaycastHit hit;
        Vector3 raycastOrigin = transform.position + Vector3.up * raycastOffsetY;
        if (Physics.Raycast(raycastOrigin, transform.forward, out hit, Mathf.Infinity))
        {
            frontObject = IsFrontObjectValid(hit) ? hit.collider.gameObject : null;
        }
    }

    private bool IsFrontObjectValid(RaycastHit hit)
    {
        return (hit.collider.CompareTag("Car") || hit.collider.CompareTag("Car Stop")) && hit.collider.gameObject != gameObject;
    }


    private void ApplyForceToTheCar()
    {
        Vector3 desiredVelocity = movementDirection * speed;
        Vector3 velocityChange = desiredVelocity - rb.velocity;

        rb.AddForce(velocityChange, ForceMode.VelocityChange);
    }

    private void RegulateSpeed()
    {
        float distanceToCar = Vector3.Distance(transform.position, frontObject.transform.position);
        if (distanceToCar < distanceStartBreaking)
        {
            BrakeCar(distanceToCar);
        }
        else
        {
            AccelerateCar();
        }
    }

    private void BrakeCar(float distanceToCar)
    {
        float breakForce = Mathf.Lerp(maxBrakeForce, minBrakeForce, distanceToCar / distanceStartBreaking);
        speed = Mathf.Clamp(speed - breakForce, 0f, speed);
    }

    private void AccelerateCar()
    {
        speed = Mathf.Clamp(speed + acceleration, 0f, maxSpeed);
    }
}
