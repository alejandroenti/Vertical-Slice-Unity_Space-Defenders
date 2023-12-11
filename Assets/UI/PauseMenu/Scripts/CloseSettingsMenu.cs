using UnityEngine;
using UnityEngine.EventSystems;

public class CloseSettingsMenu : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        UI_Manager._UI_MANAGER.CloseSettingsMenu();
        UI_Manager._UI_MANAGER.ShowPauseMenu();
    }
}
