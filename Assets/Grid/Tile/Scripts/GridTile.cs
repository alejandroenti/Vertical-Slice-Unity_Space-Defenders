using UnityEngine;
using UnityEngine.EventSystems;

public class GridTile : MonoBehaviour
{
    private void OnMouseDown()
    {
        Card card = Game_Manager._Game_Manager.GetCard();
        GameObject modelTowerPrefab = card.GetCardModel();
        GameObject tempTower = Instantiate(modelTowerPrefab, new Vector3(this.transform.position.x, 0.3f, this.transform.position.z), Quaternion.identity);

        tempTower.name = card.GetCardName();

        Grid_Manager._Grid_Manager.DestroyGrid();
        Game_Manager._Game_Manager.SetCurrentCard(null);
        Game_Manager._Game_Manager.ResetCursor();
    }
}
