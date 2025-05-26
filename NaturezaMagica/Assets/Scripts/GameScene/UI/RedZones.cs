using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RedZones : MonoBehaviour
{
    public GameObject Tip;
    public GameObject Questions;
    public TextMeshProUGUI QuestionText;
    public GameObject QuestionObject;
    public GameObject BgQuestion;

    public Image[] imagesToTurnGreen; // Assign the images you want to change to red in the Inspector

    public List<string> questionsList; // List to store questions
    public List<bool> answersList; // List to store the correct answers (true/false) corresponding to each question

    private bool isQuestionActive = false;
    private bool currentAnswer; // Stores the correct answer for the current question

    private int currentQuestionIndex = -1; // Index of the currently displayed question

    private void Start()
    {
        // Populate the questions list with your questions
        questionsList.Add("O Carvalho é uma árvore que dá flor entre os meses Abril e Maio.");
        answersList.Add(true); // The correct answer for Question 1 is true

        questionsList.Add("O Eucalipto é uma árvore natural da ilha da Madeira.");
        answersList.Add(false); 

        questionsList.Add("O que distingue visualmente os gamos macho dos gamos fêmea é o par de chifres na cabeça.");
        answersList.Add(true);

        questionsList.Add("O cavalo garrano consegue percorrer 200km em apenas 6h.");
        answersList.Add(false);

        questionsList.Add("Os patos são animais relacionados com os gansos e cisnes.");
        answersList.Add(true);

        questionsList.Add("Umas das principais características do Ganso Toulouse é o bico de cor alaranjada.");
        answersList.Add(true);

        questionsList.Add("O Cedro-de-Orégão é uma árvore que não dá nem flor nem fruto.");
        answersList.Add(false);

        questionsList.Add("Os musgos são plantas muito complexas, sem flor e sem fruto.");
        answersList.Add(false);

        questionsList.Add("As Azáleas são flores originárias da ilha da Madeira.");
        answersList.Add(false);

        questionsList.Add("Os frutos do Loureiro quando estão maduros ficam negros.");
        answersList.Add(true);

        questionsList.Add("O tentilhão é um pássaro pequeno com o bico em forma de cone, longo e grosso");
        answersList.Add(false);

        questionsList.Add("Quando as árvores são cortadas conseguimos saber quantos anos a árvore tem a partir do número de anéis presentes no seu interior.");
        answersList.Add(true);

        questionsList.Add("O Cedro-japonês pode medir até 60m de altura.");
        answersList.Add(false);

    }
  

private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isQuestionActive)
        {
            // Select and display a random question from the list
            if (questionsList.Count > 0)
            {
                int randomIndex = Random.Range(0, questionsList.Count);
                currentQuestionIndex = randomIndex; // Store the current question index
                string randomQuestion = questionsList[randomIndex];
                QuestionText.text = randomQuestion;

                // Store the correct answer for the current question
                currentAnswer = answersList[randomIndex];

                // Show the question UI
                Questions.SetActive(true);
                QuestionObject.SetActive(true);
                BgQuestion.SetActive(true);
                QuestionMode();

                isQuestionActive = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Questions.SetActive(false);
            QuestionObject.SetActive(false);
            BgQuestion.SetActive(false);
            NormalMode();

            // Reset the isQuestionActive flag when the player leaves the zone without answering
            isQuestionActive = false;
        }
    }

    public void NormalMode()
    {
        Camera.main.GetComponent<CameraMovement>().SetCameraLock(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void QuestionMode()
    {
        Camera.main.GetComponent<CameraMovement>().SetCameraLock(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ClickTrue()
    {
        if (isQuestionActive)
        {
            if (currentAnswer == true)
            {

                // Player answered correctly
                FindObjectOfType<SoundManager>().Play("Correct");
                QuestionText.text = "Correto";
                Questions.SetActive(false);
                BgQuestion.SetActive(false);
                StartCoroutine(AfterTheRightAnswer());

                // Remove the answered question and its corresponding answer from the lists
                questionsList.RemoveAt(currentQuestionIndex);
                answersList.RemoveAt(currentQuestionIndex);

                // Reset the currentQuestionIndex
                currentQuestionIndex = -1;

                // Take any additional actions you want for correct answer
            }
            else
            {
                FindObjectOfType<SoundManager>().Play("Wrong");
                QuestionText.text = "Resposta incorreta! Volta mais tarde e tenta novamente!";
                Questions.SetActive(false);
                BgQuestion.SetActive(false);
                Tip.SetActive(false);
                foreach (Image image in imagesToTurnGreen)
                {
                    image.color = Color.green;
                }
                // Take any additional actions you want for incorrect answer
            }

            isQuestionActive = false;
        }
    }

    public void ClickFalse()
    {
        if (isQuestionActive)
        {
            if (currentAnswer == false)
            {
                // Player answered correctly
                FindObjectOfType<SoundManager>().Play("Correct");
                QuestionText.text = "Correto!";
                Questions.SetActive(false);
                BgQuestion.SetActive(false);
                StartCoroutine(AfterTheRightAnswer());

                // Remove the answered question and its corresponding answer from the lists
                questionsList.RemoveAt(currentQuestionIndex);
                answersList.RemoveAt(currentQuestionIndex);

                // Reset the currentQuestionIndex
                currentQuestionIndex = -1;

                // Take any additional actions you want for correct answer
            }
            else
            {
                // Player answered incorrectly
                FindObjectOfType<SoundManager>().Play("Wrong");
                QuestionText.text = "Resposta incorreta! Volta mais tarde e tenta novamente!";
                Questions.SetActive(false);
                BgQuestion.SetActive(false);
                foreach (Image image in imagesToTurnGreen)
                {
                    image.color = Color.green;
                }
                // Take any additional actions you want for incorrect answer
            }

            isQuestionActive = false;
        }
    }

    private IEnumerator AfterTheRightAnswer()
    {
        NormalMode();
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
        Tip.SetActive(false);
        QuestionText.text = "";
    }

}

