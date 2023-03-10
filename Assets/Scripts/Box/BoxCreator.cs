using UnityEngine;

public class BoxCreator : MonoBehaviour
{
    public GameObject gridPrefab;
    public int rows = 8;
    public int columns = 4;
    public float cellSize = 1f;

    void Start()
    {
        Camera mainCamera = Camera.main;
        if (mainCamera == null)
        {
            Debug.LogError("No main camera found in the scene.");
            return;
        }

        Vector2 screenSize = new Vector2(mainCamera.pixelWidth, mainCamera.pixelHeight);
        float aspectRatio = mainCamera.aspect;
        float cameraHeight = mainCamera.orthographicSize * 2f;
        float cameraWidth = cameraHeight * aspectRatio;

        Vector2 gridSize = new Vector2(columns * cellSize, rows * cellSize);
        Vector2 gridScale = new Vector2(cameraWidth*0.1f / gridSize.x, cameraHeight * 0.6f / gridSize.y);
        Vector2 gridOffset = new Vector2(mainCamera.transform.position.x - cameraWidth / 2f + cameraWidth * 0.05f, mainCamera.transform.position.y - cameraHeight / 2f + cameraHeight * 0.1f
);
        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < columns; x++)
            {
                Vector2 spawnPosition = new Vector2(
                    x * cellSize * gridScale.x + cellSize * gridScale.x / 2f + gridOffset.x,
                    y * cellSize * gridScale.y + cellSize * gridScale.y / 2f + gridOffset.y
                );

                GameObject gridObject = Instantiate(gridPrefab, spawnPosition, Quaternion.identity);
                gridObject.transform.SetParent(transform);
            }
        }
    }
}