using UnityEngine;

public class ScreenScaler : MonoBehaviour
{
    // The reference resolution is the resolution that the game was designed for
    public Vector2 referenceResolution = new Vector2(1080, 2340);

    void Start()
    {
        // Get the current screen size
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        // Calculate the scale factor based on the reference resolution
        float scaleFactor = Mathf.Min(screenWidth / referenceResolution.x, screenHeight / referenceResolution.y);

        // Scale all objects in the scene to fit the screen
        foreach (Transform t in transform)
        {
            t.localScale = new Vector3(scaleFactor, scaleFactor, 1);
        }
    }
}
