using UnityEngine;

public class EventTriggerScript : MonoBehaviour
{
    [Header("GameObject UI")]
    [SerializeField] private GameObject ui;

    public void ShowUI()
    {
        UI_Manager._UI_MANAGER.ShowInfoGameplay(ui);
    }

    public void HideUI()
    {
        UI_Manager._UI_MANAGER.HideInfoGameplay(ui);
    }

    public void CheckAction()
    {
        if (Level_Manager._LEVEL_MANAGER.GetRoundState() == "UserAction")
        {
            if (GetComponent<TowerStats>().GetLifeAmount() == GetComponent<TowerStats>().GetActualLife())
            {
                Level_Manager._LEVEL_MANAGER.Upgrade(GetComponent<TowerStats>().GetCurrentCard());
            }
            else
            {
                float amount = GetComponent<TowerStats>().GetLifeAmount() - GetComponent<TowerStats>().GetActualLife();
                GetComponent<TowerStats>().RestoreLife(amount);
            }
        }
    }
}
