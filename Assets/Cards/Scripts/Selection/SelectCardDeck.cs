using UnityEngine;
using UnityEngine.EventSystems;

public class SelectCardDeck : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Card currentCard;

    public void SetCurrentCard(Card newCard) => currentCard = newCard;

    public void OnPointerEnter(PointerEventData eventData)
    {
        UI_Manager._UI_MANAGER.SetCardSelected(currentCard);
        UI_Manager._UI_MANAGER.ShowCardInfoUI();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        UI_Manager._UI_MANAGER.HideCardInfoUI();
    }
}
