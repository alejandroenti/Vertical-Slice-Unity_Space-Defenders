using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [Header("Pause and Settings Menu")]
    [SerializeField] private GameObject menuObject;
    [SerializeField] private GameObject settingsObject;
    [SerializeField] private GameObject menuButtonObject;

    private bool isPauseMenuShown = false;
    private bool isSettingsShown = false;

    private void Awake()
    {
        UI_Manager._UI_MANAGER.SetPauseMenu(menuObject);
        UI_Manager._UI_MANAGER.SetSettingsMenu(settingsObject);
    }

    private void Update()
    {
        isSettingsShown = settingsObject.activeSelf;

        if (isPauseMenuShown)
        {
            menuButtonObject.SetActive(false);
        }
        else
        {
            menuButtonObject.SetActive(true);
        }

        if (Input.GetButtonDown("Cancel"))
        {
            if (!isPauseMenuShown)
            {
                UI_Manager._UI_MANAGER.OpenPauseMenu();
                isPauseMenuShown = !isPauseMenuShown;
            }
            else if (!isSettingsShown)
            {
                UI_Manager._UI_MANAGER.ClosePauseMenu();
                isPauseMenuShown = !isPauseMenuShown;
            }
        }
    }

    public void SetIsPauseMenuShown(bool shown) => isPauseMenuShown = shown;
}
