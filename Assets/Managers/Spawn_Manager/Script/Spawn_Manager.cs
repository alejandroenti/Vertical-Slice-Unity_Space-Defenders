using System.Collections.Generic;
using UnityEngine;

public class Spawn_Manager : MonoBehaviour
{
    public static Spawn_Manager _SPAWN_MANAGER;

    public enum enemyClasses { BASIC, RANGE, MID, BOSS }

    [SerializeField] private List<GameObject> enemiesToSpawn = new List<GameObject>();
    [SerializeField] private Transform spawnPosition;

    // private int roundEnemies = 0;
    public int roundEnemies = 0;
    private float spawnTimer = 0.0f;
    private float spawnTime = 0.75f;

    private void Start()
    {
        UI_Manager._UI_MANAGER.UpdateEnemyCounter(roundEnemies);
    }

    private void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnTime && roundEnemies > 0)
        {
            SpawnEnemy(enemyClasses.BASIC);
        }
    }

    public void SetRoundEnemies(int roundEnemies) => this.roundEnemies = roundEnemies;

    private void SpawnEnemy(enemyClasses enemyClass)
    {
        Instantiate(enemiesToSpawn[(int)enemyClass], spawnPosition.position, Quaternion.identity);
        
        spawnTimer = 0.0f;
        roundEnemies--;
    }
}
