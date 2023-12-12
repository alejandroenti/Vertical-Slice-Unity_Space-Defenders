using UnityEngine;

public class ShotTower : MonoBehaviour
{
    [Header("Shot Settings")]
    [SerializeField] private float shotTime;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private AudioClip shotClip;
    
    private float shotTimer;

    private GameObject target;

    private SelectTarget selectTargetComponent;

    private void Awake()
    {
        selectTargetComponent = GetComponent<SelectTarget>();
        shotTimer = shotTime;
    }

    private void Update()
    {
        shotTimer += Time.deltaTime;
        
        if (selectTargetComponent.HasTarget())
        {
            target = selectTargetComponent.GetTarget();

            if (shotTimer >= shotTime)
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
        Audio_Manager._AUDIO_MANAGER.PlayFXSound(shotClip);
    }
}
