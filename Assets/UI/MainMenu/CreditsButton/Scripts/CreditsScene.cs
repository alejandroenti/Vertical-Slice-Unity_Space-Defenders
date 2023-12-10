using UnityEngine;
using UnityEngine.EventSystems;

public class CreditsScene : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Scene_Manager._SCENE_MANAGER.LoadNextScene("999_Credits");
    }
}
