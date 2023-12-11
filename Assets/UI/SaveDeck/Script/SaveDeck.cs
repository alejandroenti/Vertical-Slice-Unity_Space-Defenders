using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SaveDeck : MonoBehaviour, IPointerClickHandler
{
    [Header("Image Sounds")]
    [SerializeField] private AudioClip onSuccessClip;
    [SerializeField] private AudioClip onFailClip;

    public void OnPointerClick(PointerEventData eventData)
    {
        List<Card> cards = Deck_Controller._Deck_Controller.GetDeck();

        if (cards.Count >= 10)
        {
            Audio_Manager._AUDIO_MANAGER.PlayUISound(onSuccessClip);
            Game_Manager._Game_Manager.SetCardDeck(Deck_Controller._Deck_Controller.GetDeck());
            Scene_Manager._SCENE_MANAGER.LoadNextScene("003_Tutorial");
        }

        Audio_Manager._AUDIO_MANAGER.PlayUISound(onFailClip);
    }
}
