using UnityEngine;

public class DetectEnemyDamage : MonoBehaviour
{
    private TowerStats towerStatsComponent;

    private void Awake()
    {
        towerStatsComponent = GetComponent<TowerStats>();
    }

    public void TakeDamage(float amount)
    {
        towerStatsComponent.SubstractLife(amount);

        if (towerStatsComponent.GetLifeAmount() <= 0)
        {
            // Avisar level manager
            Level_Manager._LEVEL_MANAGER.RemoveTower(this.gameObject);
            Destroy(this.gameObject);
        }
    }
}
