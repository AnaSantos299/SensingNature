using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NotesUI : MonoBehaviour
{
    public Transform player;
    public float NoteRadius = 3f;
    
    public GameObject Tip;
    //for the sound of the notification, with this the sound will only play once
    private bool hasPlayedCorrectSound = false;
    private int som;

    private void Update()
    {
        
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= NoteRadius)
        {
            som = 1;
            Tip.SetActive(true);
        }
        else
        {
            Tip.SetActive(false);
            hasPlayedCorrectSound = false;
        }

        if (som == 1 && !hasPlayedCorrectSound)
        {
            FindObjectOfType<SoundManager>().Play("Info");
            hasPlayedCorrectSound = true;
        }
    }
}
