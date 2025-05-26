using UnityEngine.UI;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    public RectTransform playerImage;
    public Transform playerTransform;
    public float mapScale = 1.17f; // Adjust based on the ratio of map size to UI canvas size
    public Vector2 mapOffset; // Offset to position the player icon on the minimap

    private void Update()
    {
        if (playerTransform != null)
        {
            // Align the player icon to the player rotation; adjust rotation based on your game's orientation
            playerImage.rotation = Quaternion.Euler(0, 0, -playerTransform.eulerAngles.y + 90f);

            // Calculate the position of the player icon on the minimap
            Vector2 mapPosition = new Vector2(playerTransform.position.x, playerTransform.position.z) * mapScale + mapOffset;

            // Set the position of the player icon on the minimap
            playerImage.anchoredPosition = mapPosition;
        }
    }
}