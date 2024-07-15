using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider slider; // ����ġ �����̴�
    public Text numberText; // ���ڸ� ǥ���� �ؽ�Ʈ
    private int currentNumber = 1; // ���� ����
    private const int maxNumber = 11; // �ִ� ����

    void Start()
    {
        UpdateNumberText(); // �ʱ� ���� �ؽ�Ʈ ������Ʈ
        slider.onValueChanged.AddListener(OnSliderValueChange); // �����̴� �� ��ȭ ������ �߰�
    }

    private void OnSliderValueChange(float value)
    {
        if (value >= slider.maxValue) // �����̴� ���� �ִ밪�� �����ϸ�
        {
            if (currentNumber < maxNumber) // ���� ���ڰ� �ִ� ���ں��� ���� ����
            {
                currentNumber++; // ���� ����
                UpdateNumberText(); // ���� �ؽ�Ʈ ������Ʈ
                if (currentNumber < maxNumber)
                {
                    slider.value = 0; // ���ڰ� �ִ�ġ�� �������� �ʾҴٸ� �����̴� �� ����
                }
                else
                {
                    slider.value = slider.minValue + 1; // �ִ� ���ڿ� �����ϸ� �����̴��� 1�� ����
                }
            }
        }
    }

    private void UpdateNumberText()
    {
        numberText.text = currentNumber.ToString(); // ���� ���ڸ� �ؽ�Ʈ�� ������Ʈ
    }
}