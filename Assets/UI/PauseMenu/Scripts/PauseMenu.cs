using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [Header("Pause and Settings Menu")]
    [SerializeField] private GameObject menuObject;
    [SerializeField] private GameObject settingsObject;

    private bool isPauseMenuShown = false;

    private void Awake()
    {
        UI_Manager._UI_MANAGER.SetPauseMenu(menuObject);
        UI_Manager._UI_MANAGER.SetSettingsMenu(settingsObject);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            Debug.Log("ESCAPE!");

            isPauseMenuShown = !isPauseMenuShown;

            if (isPauseMenuShown)
            {
                UI_Manager._UI_MANAGER.OpenPauseMenu();
            }
            else
            {
                UI_Manager._UI_MANAGER.ClosePauseMenu();
            }
        }
    }
}
