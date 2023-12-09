using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    [SerializeField] private string cardName;
    [SerializeField] private string cardDescription;

    [SerializeField] private Sprite cardArtwork;

    [SerializeField] private int cardCost;
    [SerializeField] private int cardEffectAmount;

    public string GetCardName() => cardName;
    public string GetCardDescription() => cardDescription;
    public Sprite GetCardArtwork() => cardArtwork;
    public int GetCardCost() => cardCost;
    public int GetCardEffectAmount() => cardEffectAmount;
}
