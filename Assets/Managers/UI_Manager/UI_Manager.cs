using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    public static UI_Manager _UI_MANAGER;

    private Card cardSelected;
    [SerializeField] private GameObject cardInfoUI;

    private void Awake()
    {
        if (_UI_MANAGER != null && _UI_MANAGER != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _UI_MANAGER = this;
        }
    }

    public void ShowCardInfoUI()
    {
        cardInfoUI.SetActive(true);
    }

    public void HideCardInfoUI()
    {
        cardInfoUI.SetActive(false);
    }
}
