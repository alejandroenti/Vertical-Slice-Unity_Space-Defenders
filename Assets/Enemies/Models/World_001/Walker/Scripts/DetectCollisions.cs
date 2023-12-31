using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private EnemyStats enemyStatsComponent;

    private void Awake()
    {
        enemyStatsComponent = GetComponent<EnemyStats>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            enemyStatsComponent.SubstractLife(other.GetComponent<Bullet>().GetDamage());

            if (enemyStatsComponent.GetLifeAmount() <= 0)
            {
                // Avisar level manager
                Game_Manager._Game_Manager.AddCurrency(GetComponent<EnemyStats>().GetMoney());
                Level_Manager._LEVEL_MANAGER.RemoveEnemy(this.gameObject);
                Destroy(this.gameObject);
            }
        }
    }
}
