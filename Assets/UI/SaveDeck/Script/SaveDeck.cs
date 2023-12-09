using UnityEngine;
using UnityEngine.UI;

public class SaveDeck : MonoBehaviour
{
    Button saveDeckButton;

    private void Awake()
    {
        saveDeckButton = GetComponent<Button>();
        saveDeckButton.onClick.AddListener(SaveDeckToManager);
    }

    private void SaveDeckToManager()
    {
        Game_Manager._Game_Manager.SetCardDeck(Deck_Controller._Deck_Controller.GetDeck());

        // Pasamos a la siguiente escena
    }
}
