using TMPro;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    public float timeRemaining = 180f;

    private bool timerRunning = true;

    void Update()
    {
        if(timerRunning)
        {
            if(timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerRunning = false;

                // Ganti Debug.Log jadi trigger Game Over sungguhan
                FindObjectOfType<GameOverManager>().TriggerGameOver();
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        int minutes = Mathf.FloorToInt(timeToDisplay / 60);
        int seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}