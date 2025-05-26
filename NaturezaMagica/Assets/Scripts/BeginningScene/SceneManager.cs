using UnityEngine;
using UnityEngine.UI;


public class SceneManager : MonoBehaviour
{
    //Play and quit buttons
    public GameObject InitianB;
    //Start Button
    public GameObject StartB;
    //Background Image that gives the preview of the game
    public Image BeginnigImage;

    public void Jogar()
    {
        //desactivates the Play and quit buttons
        InitianB.SetActive(false);
        //Activares the Start Button
        StartB.SetActive(true);
        //Shows the Image that begins the transition to the game
        BeginnigImage.gameObject.SetActive(true);
    }

    public void Sair()
    {
        Debug.Log("Application Quit");
        Application.Quit();
    }

    public void Comecar ()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }
}
