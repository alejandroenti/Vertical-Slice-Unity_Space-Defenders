using UnityEngine;
using UnityEngine.EventSystems;

public class OpenSettingsMenu : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        UI_Manager._UI_MANAGER.HidePauseMenu();
        UI_Manager._UI_MANAGER.OpenSettingsMenu();
    }
}
