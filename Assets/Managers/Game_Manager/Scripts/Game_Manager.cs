using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager _Game_Manager;

    private string currentScene;

    private List<Card> cardDeck;
    private Card currentCardSelected;

    private void Awake()
    {
        if (_Game_Manager != null && _Game_Manager != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _Game_Manager = this;
            DontDestroyOnLoad(this);

            currentScene = "0001_Main_Menu";
            cardDeck = new List<Card>();
        }
    }

    public void SetCardDeck(List<Card> newCardList)
    {
        cardDeck.Clear();
        cardDeck = newCardList;
    }

    public void SetCurrentScene(string sceneName) => currentScene = sceneName;
    public void SetCurrentCard(Card newCard) => currentCardSelected = newCard;

    public Card GetCard() => currentCardSelected;

    public void SetModelInCursor(GameObject card)
    {
        Texture2D cardTexture = card.transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite.texture;
        Cursor.SetCursor(cardTexture, Vector2.zero, CursorMode.Auto);
    }

    public void ResetCursor()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    public void CloseGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
