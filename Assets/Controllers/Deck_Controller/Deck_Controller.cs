using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Deck_Controller : MonoBehaviour
{
    public static Deck_Controller _Deck_Controller;

    [Header("Deck List Container")]
    [SerializeField] private GameObject deckContainer;

    [Header("Card Deck Prefab")]
    [SerializeField] private GameObject cardDeckPrefab;

    private List<Card> deck;
    private Dictionary<Card, int> cardDictionary = new Dictionary<Card, int>();

    private void Awake()
    {
        _Deck_Controller = this;
        deck = new List<Card>();
    }

    private void Update()
    {
        Debug.Log(deck.Count);
    }

    public List<Card> GetDeck() => deck;

    public void AddCardToDeck(Card newCard)
    {
        deck.Add(newCard);

        if (cardDictionary.ContainsKey(newCard))
        {
            cardDictionary[newCard]++;
        }
        else
        {
            cardDictionary.Add(newCard, 1);
        }

        UpdateDeckList();
    }

    public void RemoveCardFromDeck(Card newCard)
    {
        if (deck.Contains(newCard))
        {
            deck.Remove(newCard);
        }

        if (cardDictionary.ContainsKey(newCard))
        {
            cardDictionary.Remove(newCard);
        }

        UpdateDeckList();
    }

    private void RemoveAllCardsFromDeck()
    {
        for (int i = deckContainer.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(deckContainer.transform.GetChild(i).gameObject);
        }
    }

    private void UpdateDeckList()
    {
        RemoveAllCardsFromDeck();

        foreach (Card card in cardDictionary.Keys)
        {
            // Instanciamos la carta y la hacemos hija del contenedor donde las spawneamos
            GameObject tempCard = Instantiate(cardDeckPrefab, deckContainer.transform);

            tempCard.transform.SetParent(deckContainer.transform);
            tempCard.name = card.name;
            tempCard.transform.name = card.name;

            // Cambiamos los campos necesarios
            tempCard.transform.GetChild(1).GetComponent<Image>().sprite = card.GetCardArtwork();
            tempCard.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = card.GetCardName();

            // En caso de haber elegido más de una carta, deberemos mostrar un texto que indique cuantas copias disponemos
            if (cardDictionary[card] <= 1)
            {
                tempCard.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = "";
            }
            else
            {
                tempCard.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = "x" + cardDictionary[card];
            }
        }
    }
}