using UnityEngine;

public class TowerStats : MonoBehaviour
{
    [Header("Tower Stats")]
    private int id;
    [SerializeField] private float lifeAmount;
    [SerializeField] private float visionRange;
    [SerializeField] private float attackSpeed;
    [SerializeField] private float attackForce;

    public int GetID() => id;
    public float GetLifeAmount() => lifeAmount;
    public void RestoreLife(float amount) => lifeAmount += amount;
    public void SubstractLife(float amount) => lifeAmount -= amount;
    public float GetVisionRange() => visionRange;
    public float GetAttackSpeed() => attackSpeed;
    public float GetAttackForce() => attackForce;
}
