using TMPro;
using UnityEngine;

public class UpdateCurrentState : MonoBehaviour
{
    private TextMeshProUGUI currentStateTextComponent;

    private void Awake()
    {
        UI_Manager._UI_MANAGER.SetCurrentStateObject(this.gameObject);
        currentStateTextComponent = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateCurrentStateText(string state)
    {
        currentStateTextComponent.text = state;
    }
}
