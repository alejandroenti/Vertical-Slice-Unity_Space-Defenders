using TMPro;
using UnityEngine;

public class UpdateCurrency : MonoBehaviour
{
    private TextMeshProUGUI currencyTextComponent;

    public void UpdateText(int amount)
    {
        currencyTextComponent.text = amount.ToString();
    }
}
