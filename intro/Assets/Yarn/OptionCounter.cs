using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OptionCounter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {   //the following aligns text left or right based on the sibling index of the object
        
        // Get the index of the child within its parent's hierarchy
        int siblingIndex = transform.GetSiblingIndex();

        //the sibling index might change if you change the structure the parent object
        if(siblingIndex == 2){
           GetComponent<TMPro.TextMeshProUGUI>().alignment = TextAlignmentOptions.Left;
        }
         if(siblingIndex == 3){
           GetComponent<TMPro.TextMeshProUGUI>().alignment = TextAlignmentOptions.Right;
        }
        
    }
}
