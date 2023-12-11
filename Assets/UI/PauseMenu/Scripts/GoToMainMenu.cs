using UnityEngine;
using UnityEngine.EventSystems;

public class GoToMainMenu : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Scene_Manager._SCENE_MANAGER.LoadNextScene("001_Main_menu");
    }
}
