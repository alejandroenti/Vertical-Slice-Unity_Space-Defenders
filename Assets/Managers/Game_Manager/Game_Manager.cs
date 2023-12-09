using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager _Game_Manager;

    private List<Card> cardDeck;

    private void Awake()
    {
        if (_Game_Manager != null && _Game_Manager != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _Game_Manager = this;

            cardDeck = new List<Card>();
        }
    }

    public void SetCardDeck(List<Card> newCardList)
    {
        cardDeck.Clear();
        cardDeck = newCardList;
    }
}
