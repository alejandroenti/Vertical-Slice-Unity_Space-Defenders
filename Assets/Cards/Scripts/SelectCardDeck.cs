using UnityEngine;
using UnityEngine.EventSystems;

public class SelectCardDeck : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        UI_Manager._UI_MANAGER.ShowCardInfoUI();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        UI_Manager._UI_MANAGER.HideCardInfoUI();
    }
}
