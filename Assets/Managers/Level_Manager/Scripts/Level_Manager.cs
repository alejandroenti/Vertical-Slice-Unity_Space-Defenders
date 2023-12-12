using System.Collections.Generic;
using UnityEngine;

public class Level_Manager : MonoBehaviour
{
    public static Level_Manager _LEVEL_MANAGER;

    [Header("Level Music")]
    [SerializeField] private AudioClip sceneMusic;

    [Header("Show Card Info (Level: Deck Selector)")]
    [SerializeField] private GameObject cardInfoGameObject;

    [Header("Currency Gameplay UI")]
    [SerializeField] public GameObject currencyTextObject;

    [SerializeField] private List<GameObject> towersList = new List<GameObject>();
    private List<GameObject> enemiesList = new List<GameObject>();

    private void Awake()
    {
        _LEVEL_MANAGER = this;

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

    public void AddTowerToLevel(GameObject tower) => towersList.Add(tower);
    public List<GameObject> GetTowers() => towersList;
    public void SetEnemies(List<GameObject> enemies) {
        enemiesList.Clear();
        enemiesList = enemies;
    }
    public List<GameObject> GetEnemies() => enemiesList;
}
