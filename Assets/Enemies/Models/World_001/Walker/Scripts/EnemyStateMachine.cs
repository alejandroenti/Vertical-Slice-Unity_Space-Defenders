using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateMachine : MonoBehaviour
{
    [Header("Attack Audio")]
    [SerializeField] private AudioClip attackClip;
    public enum States { STARTING, WALKING, ATTACKING, FINISHED, NULL }

    private States currentState = States.STARTING;
    private float attackTimer = 0.504f;

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
        ChangeState(finalPosition, States.WALKING, enemyStatsComponent.GetWalkingSpeed());
    }

    private void Walking()
    {
        // Miro si hay algún objetivo en mi campo de visión
        // Si lo hay, cambio de estado a ATTACKING
        agent.speed = enemyStatsComponent.GetWalkingSpeed();
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
                ChangeState(finalPosition, States.WALKING, enemyStatsComponent.GetWalkingSpeed());
            }
        }
    }

    private void Finished()
    {
        StayOnPlace();
    }

    private void ChangeState(Vector3 position, States newState, float speed)
    {
        targetPosition = position;
        agent.SetDestination(targetPosition);
        agent.speed = speed;
        currentState = newState;
    }

    private void CheckIfIsAnyTowerVisible()
    {
        List<GameObject> towers = Level_Manager._LEVEL_MANAGER.GetTowers();

        if (towers.Count <= 0)
        {
            ChangeState(transform.position, States.FINISHED, enemyStatsComponent.GetWalkingSpeed()); 
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
                    ChangeState(towers[i].transform.position, States.ATTACKING, enemyStatsComponent.GetRunningSpeed());
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
        agent.speed = 0f;
    }

    private void AttackToTarget()
    {
        attackTimer += Time.deltaTime;

        if (attackTimer >= enemyStatsComponent.GetAttackSpeed())
        {
            Audio_Manager._AUDIO_MANAGER.PlayFXSound(attackClip);
            towerTarget.GetComponent<DetectEnemyDamage>().TakeDamage(enemyStatsComponent.GetAttackForce());
            attackTimer = 0f;
        }
    }
}