using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour
{
    public GameObject FinalImage;
    public DropManager dropManager; // Reference to the DropManager script
    public int score = 0;
    public GameObject WarningFullGotas;
    public Image Gota10Rep;
    public TextMeshProUGUI GotasText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            FindObjectOfType<SoundManager>().Play("GotaColected");
            Destroy(other.gameObject);
            score += 10;
            Debug.Log("Gota adicionada.");

            if (score >= 10)
            {
                dropManager.SetNextDropFull();
                //score = 0; // Reset the score after filling a drop at the top
                Debug.Log(score);
            }

            if ((score >= 100) && Gota10Rep.color != Color.green)
            {
                GotasText.text = "Incrível! Com a tua ajuda consegui recolher as 10 gotas! Agora tenho de voltar para a sala inicial Rosa.";
                WarningFullGotas.SetActive(true);
                StartCoroutine(Mensagem10GotasPurificadas());

            } else if ((score >= 100) && Gota10Rep.color == Color.green)
            {
                GotasText.text = "Conseguimos recolher as 10 gotas! Oh não... as gotas estão contaminadas. Purifica as gotas na sala de purificação antes de voltares a sala inicial Rosa.";
                WarningFullGotas.SetActive(true);
                StartCoroutine(Mensagem10GotasPurificadas());
            }
        }
        //if the score its equal or bigger than 100 and the player is on the main room, it will say that the player won the game.
         if ((score >= 100) && Gota10Rep.color != Color.green)
        {
            if (other.gameObject.CompareTag("Final"))
            {
                GameEnd();
                Debug.Log("Acabou o jogo ganhou !!!!");
            }
        }
        

    }
    public void GameEnd()
    {
        Camera.main.GetComponent<CameraMovement>().SetCameraLock(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        FinalImage.SetActive(true);
    }

    private IEnumerator Mensagem10GotasPurificadas()
    {
        yield return new WaitForSeconds(7f);

        WarningFullGotas.SetActive(false);
        Debug.Log("Mensagem das 10 gotas apagada.");
    }

}
