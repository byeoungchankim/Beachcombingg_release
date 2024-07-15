using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterManager : MonoBehaviour
{
    public static CounterManager Instance;  // 싱글톤 인스턴스
    public Text counterText;  // UI Text 참조
    private int count = 0;  // 숫자 카운터

    void Awake()
    {
        // 싱글톤 패턴 구현
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateCounterText();
    }

    public void IncreaseCount()
    {
        count++;
        UpdateCounterText();
    }

    void UpdateCounterText()
    {
        counterText.text = "" + count.ToString();
    }
}