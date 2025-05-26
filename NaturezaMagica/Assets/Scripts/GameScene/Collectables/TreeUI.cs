using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreeUI : MonoBehaviour
{
    public GameObject TreeText;
    public Image Gota1;
    public ScoreUIController scoreUIController;
    private bool hasPlayedCorrectSound = false;
    private int som;


    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && (Gota1.color == Color.green))
        {
            som = 1;
            TreeText.SetActive(true);
        }

        if (som == 1 && !hasPlayedCorrectSound)
        {
            FindObjectOfType<SoundManager>().Play("Info");
            hasPlayedCorrectSound = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
   if (scoreUIController.scorePurify >= 1)
        {
            TreeText.SetActive(false);
            Destroy(this);
        }
    }

}
    
