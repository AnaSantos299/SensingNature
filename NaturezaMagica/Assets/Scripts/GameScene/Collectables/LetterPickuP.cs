using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterPickuP : MonoBehaviour
{
    public Sprite letterSprite; // The image sprite associated with this pickup
    public Image collectedLettersImage; // Reference to the Image UI element to display the collected letters
    public GameObject NoteTip;
    private bool isCollected = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!isCollected && other.CompareTag("Player"))
        {
            //the letter was collected
            FindObjectOfType<SoundManager>().Play("LetterColected");
            isCollected = true;
            //will show the letter where it was defined
            ShowCollectedLetter();
            Destroy(NoteTip);
            Destroy(gameObject);
        }
    }

    private void ShowCollectedLetter()
    {
        // Set the collected letter image spritew
        collectedLettersImage.sprite = letterSprite;
        collectedLettersImage.color = Color.white; // Reset the color of the image so its not transparent anymore
    }
}

