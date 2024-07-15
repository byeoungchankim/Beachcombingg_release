using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerLevel : MonoBehaviour
{
    public Slider slider; // 경험치 슬라이더
    public Text numberText; // 숫자를 표시할 텍스트
    public GameObject[] objects; // 관리할 오브젝트 배열
    private int currentNumber = 1; // 시작 숫자
    private const int maxNumber = 20; // 최대 숫자

    void Start()
    {
        UpdateNumberText(); // 초기 숫자 텍스트 업데이트
        UpdateObjects(); // 오브젝트 상태 업데이트
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
                UpdateObjects(); // 오브젝트 상태 업데이트
                slider.value = 0; // 슬라이더 값 리셋
            }
            else
            {
                slider.value = slider.minValue + 1; // 최대 숫자에 도달하면 슬라이더를 1에 고정
            }
        }
    }

    private void UpdateNumberText()
    {
        numberText.text = currentNumber.ToString(); // 현재 숫자를 텍스트로 업데이트
    }

    private void UpdateObjects()
    {
        // 모든 오브젝트를 비활성화
        foreach (GameObject obj in objects)
        {
            obj.SetActive(false);
        }
        // 현재 숫자에 해당하는 오브젝트만 활성화 (1부터 시작, 인덱스는 0부터 시작하므로 -1 조정)
        if (currentNumber - 1 < objects.Length)
        {
            objects[currentNumber - 1].SetActive(true);
        }
    }
}
