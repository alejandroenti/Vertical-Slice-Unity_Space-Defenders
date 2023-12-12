using UnityEngine;

public class GridTile : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Reset();
        }
    }

    private void OnMouseDown()
    {

        Card card = Game_Manager._Game_Manager.GetCard();

        if (Game_Manager._Game_Manager.GetCurrency() >= card.GetCardCost())
        {
            Game_Manager._Game_Manager.SubstractCurrency(card.GetCardCost());

            GameObject modelTowerPrefab = card.GetCardModel();
            GameObject tempTower = Instantiate(modelTowerPrefab, new Vector3(this.transform.position.x, 0.3f, this.transform.position.z), Quaternion.identity);

            tempTower.name = card.GetCardName();
            tempTower.GetComponent<TowerStats>().SetID(card.GetCardID());
            tempTower.GetComponent<TowerStats>().SetAttackForce(card.GetCardEffectAmount());

        }

        Reset();
    }

    private void Reset()
    {
        Grid_Manager._Grid_Manager.DestroyGrid();
        Game_Manager._Game_Manager.SetCurrentCard(null);
        Game_Manager._Game_Manager.ResetCursor();

        UI_Manager._UI_MANAGER.ShowDeckContainer();
    }
}
