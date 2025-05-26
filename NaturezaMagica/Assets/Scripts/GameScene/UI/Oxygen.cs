using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Oxygen : MonoBehaviour
{
    // Start is called before the first frame update
    public Image oxygen;
    public TextMeshProUGUI OxygenRep;
    float timeRemaining;
    public float max_time = 360.0f;
    public GameObject RestartMenu;
    public bool som;

    Light LightMap;
    Light LightPlayer;

    void Start()
    {
        timeRemaining = max_time;
        LightMap = GameObject.Find("LightMap").GetComponent<Light>();
        LightPlayer = GameObject.Find("LightPlayer").GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            oxygen.fillAmount = timeRemaining / max_time;
        }

        if (timeRemaining <= 30)
        {
            Debug.Log("Vermelho");
            oxygen.color = Color.red;
            LightMap.color -= (Color.white / 30.0f) * Time.deltaTime;
            LightPlayer.color -= (Color.white / 30.0f) * Time.deltaTime;
        }

        if (timeRemaining <= 0)
        {
            oxygen.color = Color.black;
            OxygenRep.color = Color.black;
            RestartMenu.SetActive(true);
            //camara stays locked
            Camera.main.GetComponent<CameraMovement>().SetCameraLock(true);
            //cursor stays unlocked and visible
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Debug.Log("DEAD");
        }
    }
}
