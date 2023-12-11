using TMPro;
using UnityEngine;

public class UpdateRounds : MonoBehaviour
{
    private TextMeshProUGUI currentRoundTextComponent;
    private TextMeshProUGUI totalRoundsTextComponent;

    private void Awake()
    {
        UI_Manager._UI_MANAGER.SetRoundsObject(this.gameObject);

        currentRoundTextComponent = this.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        totalRoundsTextComponent = this.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
    }

    public void UpdateCurrentRound(int round)
    {
        currentRoundTextComponent.text = round.ToString();
    }

    public void UpdateTotalRounds(int totalRounds)
    {
        totalRoundsTextComponent.text = totalRounds.ToString();
    }
}
