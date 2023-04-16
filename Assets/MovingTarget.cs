using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTarget : MonoBehaviour
{

    public Transform startPoint; // The starting point
    public Transform endPoint; // The end point
    public float speed = 1.0f; // The speed at which the object moves

    private Vector3 target; // The current target point
    private float targetZ; // The target Z position
    private bool isMoving; // Whether the object is currently moving

    void Start()
    {
        // Set the initial target Z position to the starting point
        targetZ = startPoint.position.z;
        isMoving = true;
    }

    void Update()
    {
        // If the object is currently moving and it has not reached the target...
        if (isMoving && transform.position.z != targetZ)
        {
            // Move towards the target Z position at the specified speed
            Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, targetZ);
            transform.position = Vector3.MoveTowards(transform.position, newPosition, speed * Time.deltaTime);
        }
        // If the object has reached the target...
        else if (isMoving && transform.position.z == targetZ)
        {
            // Switch the target Z position to the other point
            targetZ = (targetZ == startPoint.position.z) ? endPoint.position.z : startPoint.position.z;
        }
    }
}
