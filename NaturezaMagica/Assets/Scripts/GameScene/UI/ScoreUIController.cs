using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class ScoreUIController : MonoBehaviour
{
    public Image WaterRep;
    public Image[] WaterImages; // Array of water images
    public GameObject WaterBarObj;
    public Image WaterBar; // Water bar image
    public float timerDuration = 5f; // Set the timer duration in the Inspector
    public float scorePurify;

    private Color defaultColor;
    private bool isPurifying = false;

    private void Start()
    {
        defaultColor = WaterRep.color;
        WaterBarObj.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Puro") && WaterRep.color == Color.green && !isPurifying)
        {
            // Start the purification process only if the water is green and not currently purifying
            StartPurificationTimer();
        }
    }

    // Timer and bar filling in order to give a sensation of animation
    private void StartPurificationTimer()
    {
        FindObjectOfType<SoundManager>().Play("Water");
        isPurifying = true;
        WaterBarObj.SetActive(true);
        WaterBar.fillAmount = 1f; // Reset the water bar to full

        StartCoroutine(UpdateTimerBar());
        StartCoroutine(Purify());
    }

    private IEnumerator UpdateTimerBar()
    {
        float timeLeft = timerDuration;
        float fillAmount = 1f;

        while (timeLeft > 0f)
        {
            timeLeft -= Time.deltaTime;
            fillAmount = timeLeft / timerDuration;
            WaterBar.fillAmount = fillAmount;
            yield return null;
        }

        isPurifying = false; // Reset the purifying flag when the timer completes
        WaterBarObj.SetActive(false); // Hide the water bar when the timer completes
    }

    private IEnumerator Purify()
    {
        yield return new WaitForSeconds(timerDuration);

        // Purify the water array
        FindObjectOfType<SoundManager>().Play("Pure");
        foreach (Image waterImage in WaterImages)
        {
            waterImage.color = defaultColor;

        }
       scorePurify++;
    }

}
