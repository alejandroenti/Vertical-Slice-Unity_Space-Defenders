using UnityEngine;
using UnityEngine.EventSystems;

public class ResumeGame : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        UI_Manager._UI_MANAGER.ClosePauseMenu();
    }
}
