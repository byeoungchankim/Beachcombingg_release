using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TIMER : MonoBehaviour
{
    public Text timerText; // Ÿ�̸� ���� ǥ���� UI �ؽ�Ʈ
    private float timeRemaining = 60.0f;
    private bool timerIsRunning = false;

    private void Start()
    {
        timerIsRunning = true;
        timerText.color = Color.white; // �ʱ� �ؽ�Ʈ ������ ������� ����
    }

    private void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);

                // Ÿ�̸Ӱ� 10�� ���ϰ� �Ǹ� �ؽ�Ʈ ������ ���������� ����
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