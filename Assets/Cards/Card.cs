using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    private enum cardTypes { TOWER, SPELL }

    [SerializeField] private string cardName;
    [SerializeField] private string cardDescription;
    [SerializeField] private cardTypes cardType;

    [SerializeField] private Sprite cardArtwork;

    [SerializeField] private int cardCost;
    [SerializeField] private int cardEffectAmount;

    [SerializeField] private GameObject cardPrefab;
}
