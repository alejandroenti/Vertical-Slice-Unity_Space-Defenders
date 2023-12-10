using UnityEngine;
using UnityEngine.EventSystems;

public class ShowSettingsMenu : MonoBehaviour, IPointerClickHandler
{
    [Header("Setting Menu Object")]
    [SerializeField] private GameObject settingsMenuObject;

    private void Awake()
    {
        UI_Manager._UI_MANAGER.SetSettingsMenu(settingsMenuObject);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        UI_Manager._UI_MANAGER.OpenSettingsMenu();
    }
}
