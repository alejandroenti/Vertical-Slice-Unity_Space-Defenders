using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Speed")]
    [SerializeField] private float bulletSpeed;

    private GameObject target;

    private void Update()
    {
        Vector3 positionLerp = Vector3.Lerp(this.transform.position, target.transform.position, bulletSpeed * Time.deltaTime);
        transform.position = positionLerp;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag + " - BULLET");
        if (other.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }

    public void SetTaget(GameObject newTarget) => target = newTarget;
}
