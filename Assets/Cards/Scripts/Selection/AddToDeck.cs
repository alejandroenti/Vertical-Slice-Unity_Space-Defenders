using UnityEngine;
using UnityEngine.UI;

public class AddToDeck : MonoBehaviour
{
    Button addToDeckButton;

    private void Awake()
    {
        addToDeckButton = GetComponent<Button>();
        addToDeckButton.onClick.AddListener(AddCardToDeck);
    }

    private void AddCardToDeck()
    {
        Card cardToAdd = this.transform.parent.GetChild(0).GetComponent<SelectCardDeck>().GetCurrentCard();
        Deck_Controller._Deck_Controller.AddCardToDeck(cardToAdd);
    }
}
