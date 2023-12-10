using UnityEngine;

public class Level_Manager : MonoBehaviour
{
    [Header("Level Music")]
    [SerializeField] private AudioClip sceneMusic;

    [Header("Show Card Info (Level: Deck Selector)")]
    [SerializeField] private GameObject cardInfoGameObject;

    private void Awake()
    {
        Audio_Manager._AUDIO_MANAGER.PlayMusicSound(sceneMusic);

        if (Scene_Manager._SCENE_MANAGER.GetCurrentSceneName() == "002_Deck_Selection")
        {
            UI_Manager._UI_MANAGER.SetCardInfo(cardInfoGameObject);
        }
    }
}
