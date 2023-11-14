using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Manager : MonoBehaviour
{
    public static Spawn_Manager _SPAWN_MANAGER;

    public enum enemyClasses { BASIC, RANGE, MID, BOSS }

    [SerializeField] private List<GameObject> enemiesToSpawn = new List<GameObject>();
    [SerializeField] private Transform spawnPosition;

    private float spawnTimer = 0.0f;
    private float spawnTime = 5.0f;

    public void SpawnEnemy(enemyClasses enemyClass)
    {
        Instantiate(enemiesToSpawn[((int)enemyClass)], spawnPosition.position, Quaternion.identity);
    }
}
