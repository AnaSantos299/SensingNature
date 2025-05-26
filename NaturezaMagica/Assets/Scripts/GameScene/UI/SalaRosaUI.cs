using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SalaRosaUI : MonoBehaviour
{
    public Transform player;
    public float SRosaRadius = 25f;
    public Image G10Full;
    public ScoringSystem ScoringSystem;

    public GameObject Tip;

    private void Update()
    {

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if ((distanceToPlayer <= SRosaRadius) && ScoringSystem.score >= 100)
        {
            Tip.SetActive(true);
        }
        else
        {
            Tip.SetActive(false);
        }
    }
}

