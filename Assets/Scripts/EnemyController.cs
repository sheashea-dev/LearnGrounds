using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f; // Defines the area where the enemy can see the player

    public Transform target;
    public NavMeshAgent agent; // a NavMesh "Agent" is essentially an entity that will be using the NavMesh surface to move around

    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius) 
        {
            agent.SetDestination(target.position); //The target will be the player, and we set the destination of the Navmesh agent to be the same as the player, letting it chase.

            if (distance <= agent.stoppingDistance)
            {
                FaceTarget();
            }
        }
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
