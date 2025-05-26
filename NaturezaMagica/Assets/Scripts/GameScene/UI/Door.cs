using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    public GameObject DoorCode;

    [SerializeField] private TextMeshProUGUI codeText;

    string codeTextValue = "";
    public GameObject KeyPad;
    public GameObject door;

    private static Door activeDoor; // Variable to store the currently active door.
    //Ter atençao que as vezes ele recria e nao recria o dicionario.
    //iniciar o dicionario dentro do start e comento este, verificar o bug.
    //alternativa - cada vez que uso uma porta mandar o dicionario para o console e dar debug.
    private Dictionary<string, string> doorSafeCodes = new Dictionary<string, string>()
    {
        { "PinkDoor", "9352" }, // Replace "Door1" with the actual tag of your first door and "1234" with its safe code.
        { "YellowDoor", "4592" },
        { "GreenDoor", "2738" },
        { "RedDoor", "3178" },
        {"PurpleDoor", "7524" },
        {"OrangeDoor", "5183" },
        {"DarkBlueDoor", "1486" },
        {"BabyBlueDoor", "5261" },
        // Add more doors with their respective tags and safe codes as needed.
    };

    private void Update()
    {
        codeText.text = codeTextValue;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("On door");
            CodeMode();
            DoorCode.SetActive(true);
            activeDoor = this; // Set the current door as the active door.
        }
    }

    private void OnTriggerExit(Collider other)
    {
     
        if (other.CompareTag("Player"))
        {
            Debug.Log("Not on door");
            NormalMode();
            DoorCode.SetActive(false);
            activeDoor = null; // Clear the currently active door when the player exits the trigger.
        }
    }

    // Insert the digit depending on the button pressed on the key pad
    public void AddDigit(string digit)
    {
        FindObjectOfType<SoundManager>().Play("Pressed");
        codeTextValue += digit;
    }

    // Button to confirm the code
    public void ClickConfirm()
    {

        if (activeDoor == this) // Only proceed if this door is the active door.
        {
            if (doorSafeCodes.ContainsKey(gameObject.tag) && codeTextValue == doorSafeCodes[gameObject.tag])
            {
                FindObjectOfType<SoundManager>().Play("Correct");
                Debug.Log("Codigo Correto!");
                DoorCode.SetActive(false);
                Destroy(door);
                NormalMode();
            }
            else
            {
                FindObjectOfType<SoundManager>().Play("Wrong");
                Debug.Log("Codigo errado!");
                DoorCode.SetActive(false);
            }
        }
        codeTextValue = "";
    }

    // Button to reset the keyCode
    public void Clickreset()
    {
        FindObjectOfType<SoundManager>().Play("Pressed");
        codeTextValue = "";
    }

    public void NormalMode()
    {
        Camera.main.GetComponent<CameraMovement>().SetCameraLock(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void CodeMode()
    {
        Camera.main.GetComponent<CameraMovement>().SetCameraLock(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
