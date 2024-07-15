using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerLevel : MonoBehaviour
{
    public Slider slider; // ����ġ �����̴�
    public Text numberText; // ���ڸ� ǥ���� �ؽ�Ʈ
    public GameObject[] objects; // ������ ������Ʈ �迭
    private int currentNumber = 1; // ���� ����
    private const int maxNumber = 20; // �ִ� ����

    void Start()
    {
        UpdateNumberText(); // �ʱ� ���� �ؽ�Ʈ ������Ʈ
        UpdateObjects(); // ������Ʈ ���� ������Ʈ
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
                UpdateObjects(); // ������Ʈ ���� ������Ʈ
                slider.value = 0; // �����̴� �� ����
            }
            else
            {
                slider.value = slider.minValue + 1; // �ִ� ���ڿ� �����ϸ� �����̴��� 1�� ����
            }
        }
    }

    private void UpdateNumberText()
    {
        numberText.text = currentNumber.ToString(); // ���� ���ڸ� �ؽ�Ʈ�� ������Ʈ
    }

    private void UpdateObjects()
    {
        // ��� ������Ʈ�� ��Ȱ��ȭ
        foreach (GameObject obj in objects)
        {
            obj.SetActive(false);
        }
        // ���� ���ڿ� �ش��ϴ� ������Ʈ�� Ȱ��ȭ (1���� ����, �ε����� 0���� �����ϹǷ� -1 ����)
        if (currentNumber - 1 < objects.Length)
        {
            objects[currentNumber - 1].SetActive(true);
        }
    }
}
