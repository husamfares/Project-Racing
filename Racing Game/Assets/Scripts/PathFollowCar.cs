using UnityEngine;

public class PathFollowCar : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 5f;
    public float rotationSpeed = 5f;

    private int currentWaypointIndex = 0;

    void Update()
    {
        MoveCarOnPath();
    }

    void MoveCarOnPath()
    {
        if (currentWaypointIndex < waypoints.Length)
        {
            // Calculate direction towards the current waypoint
            Vector3 direction = waypoints[currentWaypointIndex].position - transform.position;

            // Move the car towards the current waypoint
            transform.position += direction.normalized * speed * Time.deltaTime;

            // Check if the car has reached the current waypoint
            if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
            {
                currentWaypointIndex++;
            }

            // Rotate the car towards the current waypoint
            if (currentWaypointIndex < waypoints.Length)
            {
                Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
        else
        {
            // Car reached the end of the path, reset the index to 0 or stop the movement
            currentWaypointIndex = 0;
        }
    }
}