using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RedZoneController : MonoBehaviour
{
    public Transform player; // Reference to the player GameObject
    public float redZoneRadius = 6f; // The distance in meters for the red zone
    public Image DropGreen;
    private bool hasPlayedCorrectSound = false;
    private int som;

    // Reference to the image you want to show
    public GameObject Tip; // Assign the image GameObject in the Inspector

    private void Update()
    {
        // Check the distance between the player and the red zone
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // If the player is within the red zone, show the image
        if (distanceToPlayer <= redZoneRadius)
        {
            som = 1;
            Tip.SetActive(true);
        }
        else
        {
            Tip.SetActive(false);
            hasPlayedCorrectSound = false;
        }

        if (DropGreen.color == Color.green)
        {
            Tip.SetActive(false);
        }

        if (som == 1 && !hasPlayedCorrectSound)
        {
            FindObjectOfType<SoundManager>().Play("Info");
            hasPlayedCorrectSound = true;
        }

    }
}
