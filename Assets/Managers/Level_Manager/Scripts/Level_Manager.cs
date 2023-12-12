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

    [Header("Tower List")]
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
            Game_Manager._Game_Manager.AddCurrency(200);
            Tutorial_Manager._TUTORIAL_MANAGER.PlayNextText();
        }

    }

    public void AddTowerToLevel(GameObject tower)
    {
        towersList.Add(tower);
        tower.GetComponent<TowerStats>().SetID(towersList.Count - 1);
    }
    public List<GameObject> GetTowers() => towersList;
    public void RemoveTower(GameObject tower)
    {
        for (int i = 0; i < towersList.Count; i++)
        {
            if (tower.GetComponent<TowerStats>().GetID() == towersList[i].GetComponent<TowerStats>().GetID())
            {
                towersList.RemoveAt(i);
                return;
            }
        }
    }
    public void AddEnemyToRound(GameObject enemy) => enemiesList.Add(enemy);
    public List<GameObject> GetEnemies() => enemiesList;
    public void ClearEnemiesList() => enemiesList.Clear();
    public void RemoveEnemy(GameObject enemy)
    {
        for (int i = 0; i < enemiesList.Count; i++)
        {
            if (enemy.GetComponent<EnemyStats>().GetID() == enemiesList[i].GetComponent<EnemyStats>().GetID())
            {
                enemiesList.RemoveAt(i);
                return;
            }
        }
    }
}
