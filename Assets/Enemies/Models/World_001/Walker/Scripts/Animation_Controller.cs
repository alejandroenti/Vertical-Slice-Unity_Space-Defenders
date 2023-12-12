using UnityEngine;
using UnityEngine.AI;

public class Animation_Controller : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator animator;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        animator.SetFloat("enemySpeed", agent.speed);
    }
}
