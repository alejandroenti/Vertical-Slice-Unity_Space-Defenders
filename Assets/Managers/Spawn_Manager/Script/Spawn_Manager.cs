using UnityEngine;

public class Spawn_Manager : MonoBehaviour
{
    public static Spawn_Manager _SPAWN_MANAGER;

    [Header("Spawn Settings")]
    [SerializeField] private float spawnTime = 0.75f;
    [SerializeField] private int roundEnemies = 0;

    [Header("Spawn Postion")]
    [SerializeField] private Transform spawnPosition;
    
    [Header("Enemy Prefab")]
    [SerializeField] private GameObject enemyPrefab;

    private float spawnTimer = 0.0f;
    private int roundEnemyID = 0;

    private bool isRoundStarted = false;

    private void Awake()
    {
        _SPAWN_MANAGER = this;
    }

    private void Start()
    {
        UI_Manager._UI_MANAGER.HideEnemyCounter();
    }

    private void Update()
    {
        if (isRoundStarted)
        {
            spawnTimer += Time.deltaTime;

            if (spawnTimer >= spawnTime && roundEnemies > 0)
            {
                SpawnEnemy(enemyPrefab);
                roundEnemyID++;
            }
        }
    }

    public int GetRoundEnemies() => roundEnemies;
    public void SetRoundEnemies(int roundEnemies)
    {
        this.roundEnemies = roundEnemies;
        this.roundEnemyID = 0;
        UI_Manager._UI_MANAGER.ShowEnemyCounter();
        UI_Manager._UI_MANAGER.UpdateEnemyCounter(this.roundEnemies);
    }

    public bool GetIsRoundStarted() => isRoundStarted;
    public void SetIsRoundStarted(bool newState)
    {
        isRoundStarted = newState;
        UI_Manager._UI_MANAGER.UpdateEnemyCounter(roundEnemies);
    }

    private void SpawnEnemy(GameObject enemy)
    {
        GameObject tempEnemy = Instantiate(enemy, spawnPosition.position, Quaternion.identity);
        tempEnemy.GetComponent<EnemyStats>().SetID(roundEnemyID);
        Level_Manager._LEVEL_MANAGER.AddEnemyToRound(tempEnemy);
        
        spawnTimer = 0.0f;
        roundEnemies--;

        if (roundEnemies <= 0)
        {
            isRoundStarted = false;
        }
    }
}
