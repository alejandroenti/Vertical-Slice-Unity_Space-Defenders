using UnityEngine;

public class Level_Manager : MonoBehaviour
{
    [Header("Level Music")]
    [SerializeField] private AudioClip sceneMusic;

    [Header("Show Card Info (Level: Deck Selector)")]
    [SerializeField] private GameObject cardInfoGameObject;

    [Header("Currency Gameplay UI")]
    [SerializeField] public GameObject currencyTextObject;

    private void Awake()
    {
        Audio_Manager._AUDIO_MANAGER.PlayMusicSound(sceneMusic);

        if (cardInfoGameObject != null)
        {
            UI_Manager._UI_MANAGER.SetCardInfo(cardInfoGameObject);
        }

        if (currencyTextObject != null)
        {
            UI_Manager._UI_MANAGER.SetCurrency(currencyTextObject);
        }
    }

    private void Start()
    {
        if (Scene_Manager._SCENE_MANAGER.GetCurrentSceneName() == "003_Tutorial")
        {
            Game_Manager._Game_Manager.AddCurrency(10);
        }
    }
}
