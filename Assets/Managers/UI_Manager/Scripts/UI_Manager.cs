using Unity.VisualScripting;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    public static UI_Manager _UI_MANAGER;

    private Card cardSelected;

    private GameObject settingsMenu;
    private GameObject cardInfoUI;
    private GameObject pauseMenu;
    private GameObject currency;
    private GameObject enemyCounterObject;
    private GameObject roundsObject;
    private GameObject deckContainerObject;
    private GameObject currentStateObject;

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

    public void SetCurrency(GameObject newCurrency) => currency = newCurrency;

    public void SetPauseMenu(GameObject newPauseMenu) => pauseMenu = newPauseMenu;
    public void SetEnemyCounter(GameObject newEnemyCounter) => enemyCounterObject = newEnemyCounter;
    public void SetRoundsObject(GameObject newRoundsObject) => roundsObject = newRoundsObject;
    public void SetDeckContainerObject(GameObject newDeckContainerObject) => deckContainerObject = newDeckContainerObject;
    public void SetCurrentStateObject(GameObject newCurrentStateObject) => currentStateObject = newCurrentStateObject;

    public void OpenSettingsMenu()
    {
        settingsMenu.SetActive(true);
    }

    public void CloseSettingsMenu()
    {
        settingsMenu.SetActive(false);
    }

    public void ShowPauseMenu()
    {
        pauseMenu.SetActive(true);
    }

    public void OpenPauseMenu()
    {
        Game_Manager._Game_Manager.StopTime();
        pauseMenu.SetActive(true);
    }

    public void HidePauseMenu()
    {
        pauseMenu.SetActive(false);
    }

    public void ClosePauseMenu()
    {
        pauseMenu.SetActive(false);
        Game_Manager._Game_Manager.ResumeTime();
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

    public void UpdateCurrencyText(float amount)
    {
        currency.GetComponent<UpdateCurrency>().UpdateText(amount);
    }

    public void UpdateEnemyCounter(int enemyCounter)
    {
        enemyCounterObject.GetComponent<UpdateEnemyCounter>().UpdateText(enemyCounter);
    }

    public void UpdateCurrentRound(int round)
    {
        roundsObject.GetComponent<UpdateRounds>().UpdateCurrentRound(round);
    }

    public void UpdateTotalRounds(int totalRounds)
    {
        roundsObject.GetComponent<UpdateRounds>().UpdateTotalRounds(totalRounds);
    }

    public void UpdateCurrentState(string state)
    {
        currentStateObject.GetComponent<UpdateCurrentState>().UpdateCurrentStateText(state);
    }

    public void SetNewCardToHand(Card newCard, int position)
    {
        deckContainerObject.GetComponent<PlaceCards>().PlaceCard(newCard, position);
    }

    public void ShowDeckContainer()
    {
        Debug.Log("SHOW");
        deckContainerObject.SetActive(true);
    }

    public void HideDeckContainer()
    {
        Debug.Log("HIDE");
        deckContainerObject.SetActive(false);
    }
}
