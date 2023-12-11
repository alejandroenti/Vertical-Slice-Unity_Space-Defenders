using UnityEngine;
using UnityEngine.EventSystems;

public class ResumeGame : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        this.transform.parent.parent.parent.parent.GetComponent<PauseMenu>().SetIsPauseMenuShown(false);
        UI_Manager._UI_MANAGER.ClosePauseMenu();
    }
}