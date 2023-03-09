using UnityEngine;

public class BoxCreator : MonoBehaviour
{
    public GameObject gridPrefab;
    public int rows = 8;
    public int columns = 4;
    public float cellSize = 1f;

    void Start()
    {
        Vector2 screenSize = new Vector2(Screen.width, Screen.height);
        Vector2 gridSize = new Vector2(columns * cellSize, rows * cellSize);
        Vector2 gridOffset = (screenSize - gridSize) / 2f;

        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < columns; x++)
            {
                Vector2 spawnPosition = new Vector2(
                    x * cellSize + cellSize / 2f + gridOffset.x,
                    y * cellSize + cellSize / 2f + gridOffset.y
                );

                GameObject gridObject = Instantiate(gridPrefab, spawnPosition, Quaternion.identity);
                gridObject.transform.SetParent(transform);
            }
        }
    }
}
