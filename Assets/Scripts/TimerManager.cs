/*
 * TimerManager script manages a timer that tracks the duration of an event in minutes and seconds.
 * It updates the timer text with the elapsed time.
 */
using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    public TMP_Text timerText; 
    private float timer; 
    private bool timerStarted; 

    // Start is called before the first frame update
    void Start()
    {
        timerStarted = false; 
        timerText.text = "0:00"; 
    }

    // Update is called once per frame
    void Update()
    {
        if (timerStarted) 
        {
            timer += Time.deltaTime; 
            UpdateTimerText();
        }
    }

    // Update the timer text with the elapsed time
    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(timer / 60F); 
        int seconds = Mathf.FloorToInt(timer - minutes * 60); 
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds); 
    }

    // Start the timer
    public void StartTimer()
    {
        timerStarted = true; 
    }
    
    public float GetElapsedTime()
    {
        return timer;
    }
    
    public void StopTimer()
    {
        timerStarted = false;
    }


}