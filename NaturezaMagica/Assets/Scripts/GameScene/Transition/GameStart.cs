using System.Collections;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    public GameObject RestartMenu;
    public GameObject gameStart;
    public float displayDuration = 3.0f;
    public PlayerMovement playerMovement;

    private void Start()
    {
        StartCoroutine(DisplayImageAndFade());
    }

    private IEnumerator DisplayImageAndFade()
    {
        RestartMenu.SetActive(false);
        gameStart.SetActive(true); // Show the objects
        Camera.main.GetComponent<CameraMovement>().SetCameraLock(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerMovement.moveSpeed = 0f;
        yield return new WaitForSeconds(displayDuration); // Wait for the duration

        gameStart.SetActive(false); // Hide the objects
        Camera.main.GetComponent<CameraMovement>().SetCameraLock(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerMovement.moveSpeed = 4f;

    }

    public void TryAgain()
    {
        int currentSceneIndex = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        UnityEngine.SceneManagement.SceneManager.LoadScene(currentSceneIndex);
    }

    public void Sair()
    {
        Debug.Log("Quit Application");
        Application.Quit();
    }
}

    

