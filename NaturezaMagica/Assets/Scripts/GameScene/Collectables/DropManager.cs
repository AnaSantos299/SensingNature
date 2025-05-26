using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropManager : MonoBehaviour
{
    public GameObject[] dropIcons; // An array to hold the drop icons (empty and full versions)
    public GameObject[] dropIcons2;
    private int currentDropIndex = 0;

    public void SetNextDropFull()
    {
        if (currentDropIndex < dropIcons.Length)
        {
            dropIcons2[currentDropIndex].SetActive(false);
            dropIcons[currentDropIndex].SetActive(true);
            currentDropIndex++;
        }
    }
}

