using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager _Game_Manager;

    private string currentScene;

    private List<Card> cardDeck;
    private Card currentCardSelected;
    private int currentCardIndex;

    private int currency = 0;

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

    public List<Card> GetCardDeck() => cardDeck;

    public void SetCurrentScene(string sceneName) => currentScene = sceneName;
    public void SetCurrentCard(Card newCard, int position)
    {
        currentCardSelected = newCard;
        currentCardIndex = position;
    }

    public Card GetCard() => currentCardSelected;
    public int GetCardPosition() => currentCardIndex;

    public void SetModelInCursor(GameObject card)
    {
        Texture2D cardTexture = card.transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite.texture;
        Cursor.SetCursor(cardTexture, Vector2.zero, CursorMode.Auto);
    }

    public int GetCurrency() => currency;
    public void AddCurrency(int amount)
    {
        currency += amount;
        UI_Manager._UI_MANAGER.UpdateCurrencyText(currency);
    }

    public void SubstractCurrency(int amount)
    {
        currency -= amount;
        UI_Manager._UI_MANAGER.UpdateCurrencyText(currency);
    }

    public void StopTime()
    {
        Time.timeScale = 0;
    }

    public void ResumeTime()
    {
        Time.timeScale = 1;
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
