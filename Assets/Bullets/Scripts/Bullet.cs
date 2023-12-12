using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Speed")]
    [SerializeField] private float bulletSpeed;

    private GameObject target;
    private float damage;

    private void Update()
    {
        if (target == null)
        {
            Destroy(this.gameObject);
        }

        Vector3 positionLerp = Vector3.Lerp(this.transform.position, target.transform.position, bulletSpeed * Time.deltaTime);
        transform.position = positionLerp;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }

    public void SetTaget(GameObject newTarget) => target = newTarget;
    public void SetDamage(float newDamage) => damage = newDamage;
    public float GetDamage() => damage;
}
