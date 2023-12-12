using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AddToDeck : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Card cardToAdd = this.transform.parent.GetChild(0).GetChild(0).GetComponent<SelectCardDeck>().GetCurrentCard();
        Deck_Controller._Deck_Controller.AddCardToDeck(cardToAdd);
    }
}
