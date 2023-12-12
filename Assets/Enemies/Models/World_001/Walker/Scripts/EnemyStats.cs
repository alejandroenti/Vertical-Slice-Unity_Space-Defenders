using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [Header("Enemy Stats")]
    private int id;
    [SerializeField] private float lifeAmount;
    [SerializeField] private float visionRange;
    [SerializeField] private float visionAngle;
    [SerializeField] private float attackRange;
    [SerializeField] private float attackSpeed;
    [SerializeField] private float attackForce;
    [SerializeField] private float walkingSpeed;
    [SerializeField] private float runningSpeed;
    [SerializeField] private int money;

    public int GetID() => id;
    public void SetID(int newID) => id = newID;
    public float GetLifeAmount() => lifeAmount;
    public void SubstractLife(float amount) => lifeAmount -= amount;
    public float GetVisionRange() => visionRange;
    public float GetVisionAngle() => visionAngle;
    public float GetAttackRange() => attackRange;
    public float GetAttackSpeed() => attackSpeed;
    public float GetAttackForce() => attackForce;
    public float GetWalkingSpeed() => walkingSpeed;
    public float GetRunningSpeed() => runningSpeed;
    public int GetMoney() => money;
}
