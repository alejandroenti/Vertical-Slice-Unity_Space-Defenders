using UnityEngine;

public class ShotTower : MonoBehaviour
{
    [Header("Shot Settings")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private AudioClip shotClip;
    
    private float shotTimer;

    private GameObject target;

    private SelectTarget selectTargetComponent;
    private TowerStats towerStatsComponent;

    private void Awake()
    {
        selectTargetComponent = GetComponent<SelectTarget>();
        towerStatsComponent = GetComponent<TowerStats>();

        shotTimer = towerStatsComponent.GetAttackSpeed();
    }

    private void Update()
    {
        shotTimer += Time.deltaTime;
        
        if (selectTargetComponent.HasTarget())
        {
            target = selectTargetComponent.GetTarget();

            if (shotTimer >= towerStatsComponent.GetAttackSpeed())
            {
                Shot();
                shotTimer = 0f;
            }
        }
    }

    private void Shot()
    {
        GameObject tempBullet = Instantiate(bulletPrefab, this.transform.GetChild(0));
        tempBullet.GetComponent<Bullet>().SetTaget(target);
        tempBullet.GetComponent<Bullet>().SetDamage(towerStatsComponent.GetAttackForce());
        Audio_Manager._AUDIO_MANAGER.PlayFXSound(shotClip);
    }
}
