using UnityEngine;

public class PathFollowCar : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 5f;
    public float rotationSpeed = 5f; // Adjust the rotation speed

    private int currentWaypointIndex = 0;

    void Update()
    {
        MoveCarOnPath();
    }

    void MoveCarOnPath()
    {
        if (currentWaypointIndex < waypoints.Length)
        {
            // Move towards the current waypoint
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, speed * Time.deltaTime);

            // Rotate towards the current waypoint
            Vector2 direction = (transform.position - waypoints[currentWaypointIndex].position  ).normalized;
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), rotationSpeed * Time.deltaTime);

            // Check if the car has reached the current waypoint
            if (Vector2.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
            {
                currentWaypointIndex++;
            }
        }
        else
        {
            // Car reached the end of the path, you can restart the path or stop the movement
            // For simplicity, let's reset the index to 0
            currentWaypointIndex = 0;
        }
    }
}
