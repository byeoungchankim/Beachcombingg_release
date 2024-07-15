using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider slider; // 경험치 슬라이더
    public Text numberText; // 숫자를 표시할 텍스트
    private int currentNumber = 1; // 시작 숫자
    private const int maxNumber = 11; // 최대 숫자

    void Start()
    {
        UpdateNumberText(); // 초기 숫자 텍스트 업데이트
        slider.onValueChanged.AddListener(OnSliderValueChange); // 슬라이더 값 변화 리스너 추가
    }

    private void OnSliderValueChange(float value)
    {
        if (value >= slider.maxValue) // 슬라이더 값이 최대값에 도달하면
        {
            if (currentNumber < maxNumber) // 현재 숫자가 최대 숫자보다 작을 때만
            {
                currentNumber++; // 숫자 증가
                UpdateNumberText(); // 숫자 텍스트 업데이트
                if (currentNumber < maxNumber)
                {
                    slider.value = 0; // 숫자가 최대치에 도달하지 않았다면 슬라이더 값 리셋
                }
                else
                {
                    slider.value = slider.minValue + 1; // 최대 숫자에 도달하면 슬라이더를 1에 고정
                }
            }
        }
    }

    private void UpdateNumberText()
    {
        numberText.text = currentNumber.ToString(); // 현재 숫자를 텍스트로 업데이트
    }
}