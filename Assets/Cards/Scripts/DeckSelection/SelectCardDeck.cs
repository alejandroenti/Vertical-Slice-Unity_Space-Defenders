using UnityEngine;
using UnityEngine.EventSystems;

public class SelectCardDeck : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Buttons Sounds")]
    [SerializeField] private AudioClip hoverSound;
    [SerializeField] private AudioClip exitdSound;

    private Card currentCard;

    public Card GetCurrentCard() => currentCard;
    public void SetCurrentCard(Card newCard) => currentCard = newCard;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Audio_Manager._AUDIO_MANAGER.PlayUISound(hoverSound);
        UI_Manager._UI_MANAGER.SetCardSelected(currentCard);

        if (Scene_Manager._SCENE_MANAGER.GetCurrentSceneName() == "002_Deck_Selection")
        {
            UI_Manager._UI_MANAGER.ShowCardInfoUI(currentCard);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Audio_Manager._AUDIO_MANAGER.PlayUISound(exitdSound);

        if (Scene_Manager._SCENE_MANAGER.GetCurrentSceneName() == "002_Deck_Selection")
        {
            UI_Manager._UI_MANAGER.HideCardInfoUI();
        }
    }
}
