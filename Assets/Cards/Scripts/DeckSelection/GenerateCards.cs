using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GenerateCards : MonoBehaviour
{
    [Header("Card List")]
    [SerializeField] private List<Card> cards = new List<Card>();
    
    
    [Header("Card Selection Prefab")]
    [SerializeField] private GameObject cardPrefab;


    private void Start()
    {
        GenerateCardsUI();
    }

    private void GenerateCardsUI()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            // Instaciamos el prefab de la carta y nos la guardamos para poder realizarle los cambios de padre y nombre
            GameObject tempCard = Instantiate(cardPrefab, this.transform);

            // Retiramos la animación de la carta: Sólo para GAMEPLAY
            tempCard.transform.GetChild(0).GetChild(0).GetComponent<SelectHandler>().enabled = false;

            tempCard.transform.SetParent(this.transform);
            tempCard.name = "Card_" + i.ToString("000");
            tempCard.transform.name = "Card_" + i.ToString("000");

            // Nos guardamos el prefab propio de la carta y vamos aplicando los cambios para cada componente de la carta
            GameObject tempCardAspects = tempCard.transform.GetChild(0).transform.GetChild(0).gameObject;

            tempCardAspects.transform.GetChild(0).transform.GetChild(1).GetComponent<Image>().sprite = cards[i].GetCardArtwork();
            tempCardAspects.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = cards[i].GetCardName();
            tempCardAspects.transform.GetChild(3).transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = cards[i].GetCardCost().ToString();
            tempCardAspects.transform.GetChild(4).transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = cards[i].GetCardEffectAmount().ToString();

            // Pasamos la carta que estamos creando al Script SelectCardDeck para que tenga una referencia de ella misma como Carta
            tempCard.transform.GetChild(0).GetComponent<SelectCardDeck>().SetCurrentCard(cards[i]);
        }
    }
}
