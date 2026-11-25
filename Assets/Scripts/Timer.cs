using UnityEngine;
using TMPro;
using DG.Tweening;
using System.Collections;

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
        StartCoroutine(AnimateTimerCoroutine());
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

    public IEnumerator AnimateTimerCoroutine()
    {
        while (playing == true)
        {
            timerText.transform.DOScale(1.1f, 0.2f).OnComplete(() => timerText.transform.DOScale(1f, 0.2f));
            yield return new WaitForSeconds(1f);
        }
    }

    public void ResetTimer() //not using
    {
        timer = 0f;
        int minutes = Mathf.FloorToInt(timer / 60f);
        int seconds = Mathf.FloorToInt(timer % 60f);
        timerText.text = minutes.ToString ("00") + ":" + seconds.ToString ("00");
    }
}
