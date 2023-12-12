using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SaveDeck : MonoBehaviour, IPointerClickHandler
{
    [Header("Image Sounds")]
    [SerializeField] private AudioClip onSuccessClip;
    [SerializeField] private AudioClip onFailClip;

    private int cardID = 1;

    public void OnPointerClick(PointerEventData eventData)
    {
        List<Card> cards = Deck_Controller._Deck_Controller.GetDeck();

        if (cards.Count >= 10)
        {
            Audio_Manager._AUDIO_MANAGER.PlayUISound(onSuccessClip);
            Game_Manager._Game_Manager.SetCardDeck(ApplyIDToCards(Deck_Controller._Deck_Controller.GetDeck()));
            Scene_Manager._SCENE_MANAGER.LoadNextScene("003_Tutorial");
        }

        Audio_Manager._AUDIO_MANAGER.PlayUISound(onFailClip);
    }

    private List<Card> ApplyIDToCards(List<Card> cards)
    {
        for (int i = 0; i < cards.Count; i++)
        {
            cards[i].SetCardID(cardID);
            cardID++;
        }

        return cards;
    }
}
