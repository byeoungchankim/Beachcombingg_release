using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameContdown : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text countdownText;
    public GameObject Level;
    private float startTime;

    private void Start()
    {
        if (countdownText != null)
        {
            Time.timeScale = 0f; //게임 정지
            StartCoroutine(StartGame());
        }
    }
    private IEnumerator StartGame()
    {
        countdownText.text = "3";
        startTime = Time.realtimeSinceStartup;
        yield return new WaitForSecondsRealtime(1);
        countdownText.text = "2";
        yield return new WaitForSecondsRealtime(1);
        countdownText.text = "1";
        yield return new WaitForSecondsRealtime(1);
        countdownText.text = "GO!";
        yield return new WaitForSecondsRealtime(1);
        Level.gameObject.SetActive(true);
        countdownText.gameObject.SetActive(false);
        Time.timeScale = 1f; // 게임 시작
    }
}
