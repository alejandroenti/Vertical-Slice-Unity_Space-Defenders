using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    private int cardID;

    [SerializeField] private string cardName;
    [SerializeField] private string cardDescription;

    [SerializeField] private Sprite cardArtwork;

    [SerializeField] private int cardCost;
    [SerializeField] private int cardEffectAmount;

    [SerializeField] private GameObject cardModel;
    [SerializeField] private Card cardUpgraded;

    public int GetCardID() => cardID;
    public void SetCardID(int newID) => cardID = newID;
    public string GetCardName() => cardName;
    public string GetCardDescription() => cardDescription;
    public Sprite GetCardArtwork() => cardArtwork;
    public int GetCardCost() => cardCost;
    public int GetCardEffectAmount() => cardEffectAmount;
    public GameObject GetCardModel() => cardModel;
    public Card GetCardUpgraded() => cardUpgraded;
}
