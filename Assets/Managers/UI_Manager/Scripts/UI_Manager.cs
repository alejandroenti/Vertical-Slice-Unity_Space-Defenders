using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    public static UI_Manager _UI_MANAGER;

    private Card cardSelected;

    private GameObject settingsMenu;
    private GameObject cardInfoUI;

    private MountDescriptionCard mountDescriptionCardScript;

    private void Awake()
    {
        if (_UI_MANAGER != null && _UI_MANAGER != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _UI_MANAGER = this;
            DontDestroyOnLoad(this);
        }
    }

    public void SetSettingsMenu(GameObject newSettingsMenu) => settingsMenu = newSettingsMenu;
    public void SetCardSelected(Card newCard) => cardSelected = newCard;
    public void SetCardInfo(GameObject newCardInfo)
    {
        cardInfoUI = newCardInfo;
        mountDescriptionCardScript = cardInfoUI.GetComponent<MountDescriptionCard>();
    }

    public void OpenSettingsMenu()
    {
        settingsMenu.SetActive(true);
    }

    public void CloseSettingsMenu()
    {
        settingsMenu.SetActive(false);
    }

    public void ShowCardInfoUI()
    {
        cardInfoUI.SetActive(true);
        mountDescriptionCardScript.MountCard(cardSelected);
    }

    public void HideCardInfoUI()
    {
        cardInfoUI.SetActive(false);
        cardSelected = null;
    }
}
