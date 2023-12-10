using UnityEngine;
using UnityEngine.EventSystems;

public class PlayScene : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Scene_Manager._SCENE_MANAGER.LoadNextScene("002_Deck_Selection");
    }
}
