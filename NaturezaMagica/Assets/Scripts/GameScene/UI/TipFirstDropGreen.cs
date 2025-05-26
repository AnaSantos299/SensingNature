using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class TipFirstDropGreen : MonoBehaviour
{
    public Image FirstDrop;
    public GameObject TipDirtyDrop;

    void Update()
    {
        if (FirstDrop.color == Color.green)
        {
            TipDirtyDrop.SetActive(true);

            StartCoroutine(HideTipDirtyDrop());
        }
    }

    private IEnumerator HideTipDirtyDrop()
    {
        TipDirtyDrop.SetActive(true);

        yield return new WaitForSeconds(5f);

        TipDirtyDrop.SetActive(false);

        Destroy(this);
    }
}
