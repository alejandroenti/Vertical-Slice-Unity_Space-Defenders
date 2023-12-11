using UnityEngine;
using UnityEngine.EventSystems;

public class ShowPauseMenu : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject.FindGameObjectWithTag("PauseMenu").GetComponent<PauseMenu>().SetIsPauseMenuShown(true);
        UI_Manager._UI_MANAGER.OpenPauseMenu();
    }
}
