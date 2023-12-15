using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float remainingTime;
    public TextMeshProUGUI timerText;
    private bool isTimerRunning = false;  // 시간이 흐르는지
    private bool isTimeOut = false;  // 타임아웃이벤트를 한번만 호출하기위함

    private void Start()
    {
        
        ResumeTimer();
    }

    void Update()
    {
        if (isTimerRunning && remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            UpdateTimerText();
        }
        else if (remainingTime <= 0 && !isTimeOut && isTimerRunning)
        {
            timerText.text = "Time Over!";
            // gamemanager event only once
            GameManager.Instance.LoadWinScene();
            isTimeOut = true;
        }
    }

    public void SetRemainingTime(float time)
    {
        remainingTime = time;
        isTimeOut = false;
        UpdateTimerText();
    }

    void UpdateTimerText()
    {
        // Convert remainingTime to minutes, seconds, and milliseconds.
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        int mseconds = Mathf.FloorToInt((remainingTime * 100) % 100);

        // Format the time as a string with minute:second.millisecond.
        timerText.text = string.Format("{0:D2}:{1:D2}.{2:D2}", minutes, seconds, mseconds);
    }

    public void StopTimer()
    {
        isTimerRunning = false;
    }

    public void ResumeTimer()
    {
        isTimerRunning = true;
    }

    
}
