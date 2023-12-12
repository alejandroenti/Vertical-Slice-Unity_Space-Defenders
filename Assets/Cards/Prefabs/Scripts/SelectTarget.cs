using System.Collections.Generic;
using UnityEngine;

public class SelectTarget : MonoBehaviour
{
    private GameObject target;
    private float targetDistance = 1000000f;
    private List<GameObject> enemies = new List<GameObject>();

    private TowerStats towerStatsComponent;

    private void Awake()
    {
        towerStatsComponent = GetComponent<TowerStats>();
    }

    private void LateUpdate()
    {
        enemies = Level_Manager._LEVEL_MANAGER.GetEnemies();

        if (target == null)
        {
            targetDistance = 1000000f;
        }

        for (int i = 0; i < enemies.Count; i++)
        {
            Vector3 distanceVector = enemies[i].transform.position - transform.position;
            float distance = distanceVector.magnitude;

            if (distance < targetDistance && distance <= towerStatsComponent.GetVisionRange())
            {
                target = enemies[i];
                targetDistance = distance;
            }
        }
    }

    public bool HasTarget() => target != null;
    public GameObject GetTarget() => target;
}