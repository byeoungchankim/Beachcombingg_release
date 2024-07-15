using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TIMER : MonoBehaviour
{
    public Text timerText; // 타이머 값을 표시할 UI 텍스트
    private float timeRemaining = 60.0f;
    private bool timerIsRunning = false;

    private void Start()
    {
        timerIsRunning = true;
        timerText.color = Color.white; // 초기 텍스트 색상을 흰색으로 설정
    }

    private void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);

                // 타이머가 10초 이하가 되면 텍스트 색상을 빨간색으로 변경
                if (timeRemaining <= 10.0f)
                {
                    timerText.color = Color.red;
                }
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                timerText.text = "0:00";
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}