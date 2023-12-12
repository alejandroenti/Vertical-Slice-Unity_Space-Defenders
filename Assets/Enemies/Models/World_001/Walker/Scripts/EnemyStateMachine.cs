using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateMachine : MonoBehaviour
{
    private enum States { STARTING, WALKING, ATTACKING, FINISHED }

    private States currentState = States.STARTING;
    private float attackTimer = 0f;

    private NavMeshAgent agent;
    private Vector3 finalPosition;
    private Vector3 targetPosition;
    private GameObject towerTarget;

    private EnemyStats enemyStatsComponent;

    private void Awake()
    {
        enemyStatsComponent = GetComponent<EnemyStats>();

        agent = GetComponent<NavMeshAgent>();
        finalPosition = GameObject.FindGameObjectWithTag("Finish").transform.position;
    }

    private void Update()
    {
        switch (currentState)
        {
            case States.STARTING:
                Starting();
                break;
            case States.WALKING:
                Walking();
                break;
            case States.ATTACKING:
                Attacking();
                break;
            case States.FINISHED:
                Finished();
                break;
            default:
                break;
        }
    }

    private void Starting()
    {
        ChangeState(finalPosition, States.WALKING);
    }

    private void Walking()
    {
        // Miro si hay algún objetivo en mi campo de visión
        // Si lo hay, cambio de estado a ATTACKING
        CheckIfIsAnyTowerVisible();
    }

    private void Attacking()
    {
        // Me acerco al objetivo
        // Si esta cerca, lo ataco
        if (HasArrivedToTower())
        {
            StayOnPlace();
            AttackToTarget();
            // Compruebo si sigue vivo
            // Si no lo está, cambio de estado a WALKING
            if (towerTarget == null)
            {
                ChangeState(finalPosition, States.WALKING);
            }
        }
    }

    private void Finished()
    {

    }

    private void ChangeState(Vector3 position, States newState)
    {
        targetPosition = position;
        agent.SetDestination(targetPosition);
        currentState = newState;
    }

    private void CheckIfIsAnyTowerVisible()
    {
        List<GameObject> towers = Level_Manager._LEVEL_MANAGER.GetTowers();

        if (towers.Count <= 0)
        {
            ChangeState(transform.position, States.FINISHED); 
            return;
        }

        for (int i = 0; i < towers.Count; i++)
        {
            Vector3 positionVector = towers[i].transform.position - transform.position;
            float distance = positionVector.magnitude;

            if (distance <= enemyStatsComponent.GetVisionRange())
            {
                positionVector.Normalize();

                if (Vector3.Angle(transform.forward, positionVector) <= enemyStatsComponent.GetVisionAngle())
                {
                    ChangeState(towers[i].transform.position, States.ATTACKING);
                    towerTarget = towers[i];
                }
            }
        }
    }

    private bool HasArrivedToTower()
    {
        Vector3 positionVector = targetPosition - transform.position;
        float distance = positionVector.magnitude;

        return distance < enemyStatsComponent.GetAttackRange();
    }

    private void StayOnPlace()
    {
        targetPosition = transform.position;
        agent.SetDestination(targetPosition);
    }

    private void AttackToTarget()
    {
        attackTimer += Time.deltaTime;

        if (attackTimer >= enemyStatsComponent.GetAttackSpeed())
        {
            towerTarget.GetComponent<DetectEnemyDamage>().TakeDamage(enemyStatsComponent.GetAttackForce());
            attackTimer = 0f;
        }
    }
}