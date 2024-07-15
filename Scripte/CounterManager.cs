using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterManager : MonoBehaviour
{
    public static CounterManager Instance;  // �̱��� �ν��Ͻ�
    public Text counterText;  // UI Text ����
    private int count = 0;  // ���� ī����

    void Awake()
    {
        // �̱��� ���� ����
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