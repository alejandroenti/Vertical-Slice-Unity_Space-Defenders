using TMPro;
using UnityEngine;

public class UpdateEnemyCounter : MonoBehaviour
{
    private TextMeshProUGUI textComponent;

    private void Awake()
    {
        UI_Manager._UI_MANAGER.SetEnemyCounter(gameObject);
        textComponent = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateText(int amount)
    {
        textComponent.text = amount.ToString();
    }
}
