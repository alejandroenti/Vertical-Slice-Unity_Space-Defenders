using UnityEngine;
using UnityEngine.AI;

public class MovementToPoint : MonoBehaviour
{
    private Vector3 targetPosition;
    private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        targetPosition = GameObject.FindGameObjectWithTag("Finish").transform.position;
    }

    private void Start()
    {
        agent.SetDestination(targetPosition);
    }

    private void Update()
    {
        if (Vector3.Distance(agent.transform.position, targetPosition) < 0.5f)
        {
            Destroy(gameObject);
        }
    }
}
