using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag + " - ENEMY");
        if (other.tag == "Bullet")
        {
            Destroy(this.gameObject);
        }
    }
}
