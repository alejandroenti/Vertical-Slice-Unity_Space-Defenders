using TMPro;
using UnityEngine;

public class UpdateCurrency : MonoBehaviour
{
    private TextMeshProUGUI currencyTextComponent;

    private void Awake()
    {
        currencyTextComponent = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateText(float amount)
    {
        //Debug.Log(currencyTextComponent.text + " - " + amount.ToString());
        currencyTextComponent.text = amount.ToString();
    }
}
