using UnityEngine;

public class GhostPatrol : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 3f;
    private int currentWaypointIndex = 0;

    void Update()
        // Використовуємо Update або FixedUpdate для руху
    {
        // Якщо точок немає, нічого не робимо
        if (waypoints == null || waypoints.Length == 0) return;

        Transform targetWaypoint = waypoints[currentWaypointIndex];

        // Рухаємося плавно до поточної точки
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);

        // Перевіряємо, чи привид дійшов до точки
        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            // Переходимо до наступної точки циклічно
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }
}