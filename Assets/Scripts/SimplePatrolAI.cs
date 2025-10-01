using UnityEngine;
using UnityEngine.AI;

public class SimplePatrolAI : MonoBehaviour
{
    [Header("Waypoints del recorrido")]
    public Transform[] waypoints;
    public float reachDistance = 0.5f;

    private NavMeshAgent agent;
    private int currentWaypointIndex = 0;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (waypoints.Length > 0)
        {
            agent.SetDestination(waypoints[currentWaypointIndex].position);
        }
    }

    void Update()
    {
        if (waypoints.Length == 0) return;

        
        if (!agent.pathPending && agent.remainingDistance <= reachDistance)
        {
            currentWaypointIndex++;

            
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }

            agent.SetDestination(waypoints[currentWaypointIndex].position);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        for (int i = 0; i < waypoints.Length; i++)
        {
            if (waypoints[i] != null)
            {
                Gizmos.DrawSphere(waypoints[i].position, 0.2f);
                if (i + 1 < waypoints.Length && waypoints[i + 1] != null)
                    Gizmos.DrawLine(waypoints[i].position, waypoints[i + 1].position);
                else if (i == waypoints.Length - 1 && waypoints[0] != null)
                    Gizmos.DrawLine(waypoints[i].position, waypoints[0].position);
            }
        }
    }
}
