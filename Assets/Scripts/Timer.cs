using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public GameObject player;
    public GameObject gameOverUI;
    public TextMeshProUGUI timerText;
    public bool playing;
    private static float timer;

    private void Awake()
    {
        playing = true;
    }
    private void Update()
    {
        if(playing == true)
        {
            timer += Time.deltaTime;
            int minutes = Mathf.FloorToInt(timer / 60f);
            int seconds = Mathf.FloorToInt(timer % 60f);
            timerText.text = minutes.ToString ("00") + ":" + seconds.ToString ("00");
        }

        if(playing == false) //wont get used really
        {
            timer -= Time.deltaTime;
            gameOverUI.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void ResetTimer()
    {
        timer = 0f;
        int minutes = Mathf.FloorToInt(timer / 60f);
        int seconds = Mathf.FloorToInt(timer % 60f);
        timerText.text = minutes.ToString ("00") + ":" + seconds.ToString ("00");
    }
}
