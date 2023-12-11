using UnityEngine;

public class Grid_Manager : MonoBehaviour
{
    public static Grid_Manager _Grid_Manager;

    [Header("Grid Size Variables")]
    [SerializeField] private int gridWidth;
    [SerializeField] private int gridHeight;

    [Header("Grid Tile Prefab")]
    [SerializeField] private GameObject gridContainer;
    [SerializeField] private GameObject gridTilePrefab;

    [Header("Grid Materials")]
    [SerializeField] private Material darkMaterial;
    [SerializeField] private Material lightMaterial;

    private float startX;
    private float startZ;

    private float positionX;
    private float positionZ;

    private float yValue = 0.32f;
    private float offset = 0.5f;

    private void Awake()
    {
        if (_Grid_Manager != null &&  _Grid_Manager != this) 
        {
            Destroy(gameObject);
        }
        else
        {
            _Grid_Manager = this;

            startX = (gridWidth / 2);
            startZ = -(gridHeight / 2) + offset;

            gridHeight -= 1;

            positionX = startX + 1f;
            positionZ = startZ - 1f;
        } 
    }

    public void GenerateGrid()
    {
        int counter = 0;

        for (int i = 0; i < gridHeight; i++)
        {
            positionZ += 1f;

            for(int j = 0; j < gridWidth; j++)
            {
                positionX -= 1f;

                GameObject tempTile = Instantiate(gridTilePrefab, new Vector3(positionX, yValue, positionZ), Quaternion.identity);
                tempTile.transform.SetParent(gridContainer.transform);
                tempTile.name = "Tile_" + counter.ToString("000");
                tempTile.transform.name = "Tile_" + counter.ToString("000");

                tempTile.GetComponent<MeshRenderer>().material = ((i % 2 == 0 && j % 2 != 0) || (i % 2 != 0 && j % 2 == 0)) ? lightMaterial : darkMaterial;
                    
               counter++;
            }

            positionX = startX + 1f;
        }
    }

    public void DestroyGrid()
    {
        for (int i = gridContainer.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(gridContainer.transform.GetChild(i).gameObject);
        }
    }
}
