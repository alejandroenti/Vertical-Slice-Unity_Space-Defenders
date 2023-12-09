using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager _Game_Manager;

    [SerializeField] private List<Card> cardDeck;

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

    public void SetModelInCursor(GameObject card)
    {
        Texture2D cardTexture = card.transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite.texture;
        Cursor.SetCursor(cardTexture, Vector2.zero, CursorMode.Auto);
    }
}
