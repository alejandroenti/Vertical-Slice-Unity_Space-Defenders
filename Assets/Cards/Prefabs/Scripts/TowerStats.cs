using UnityEngine;

public class TowerStats : MonoBehaviour
{
    [Header("Tower Stats")]
    [SerializeField] private int id;
    [SerializeField] private float lifeAmount;
    [SerializeField] private float visionRange;
    [SerializeField] private float attackSpeed;
    [SerializeField] private float attackForce;


    private Card currentCard;
    private float actualLife;

    private void Awake()
    {
        actualLife = lifeAmount;
    }

    public int GetID() => id;
    public void SetID(int newID) => id = newID;
    public float GetLifeAmount() => lifeAmount;
    public float GetActualLife() => actualLife;
    public void RestoreLife(float amount) => actualLife += amount;
    public void SubstractLife(float amount) => actualLife -= amount;
    public float GetVisionRange() => visionRange;
    public float GetAttackSpeed() => attackSpeed;
    public float GetAttackForce() => attackForce;
    public float SetAttackForce(float amount) => attackForce = amount;
    public void SetCurrentCard(Card card) => currentCard = card;
    public Card GetCurrentCard() => currentCard;
}
