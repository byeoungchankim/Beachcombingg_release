using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamFlower : MonoBehaviour
{
    public Transform target; // 카메라가 따라갈 대상
    public Vector3 initialOffset; // 초기 오프셋
    public int currentLevel; // 현재 레벨
    public Text levelText; // 레벨을 표시할 텍스트 UI

    private Vector3[] levelOffsets = {
        new Vector3(0, 1, -3), // 레벨 1
        new Vector3(0, 2f, -4f), // 레벨 2
        new Vector3(0, 6, -8f), // 레벨 3
        new Vector3(0, 10f, -12f), // 레벨 4
        new Vector3(0, 20, -20f), // 레벨 5
        new Vector3(0, 25f, -24f), // 레벨 6
        new Vector3(0, 30f, -28f), // 레벨 7
        new Vector3(0, 60f, -30f), // 레벨 8
        new Vector3(0, 80f, -40f), // 레벨 9
        new Vector3(0, 100f, -50f), // 레벨 10
         
    };

    private float[] rotationXs = {
        1f, // 레벨 1
        10f, // 레벨 2
        20f, // 레벨 3
        25f, // 레벨 4
        30f, // 레벨 5
        35f, // 레벨 6
        40f, // 레벨 7
        45f, // 레벨 8
        50f, // 레벨 9
        50f, // 레벨 10
        50f // 레벨 11
    };

    private float rotationX = 0f; // X축 회전을 위한 변수

    void Start()
    {
        // 게임 시작 시 초기 오프셋 설정
        initialOffset = levelOffsets[0];

        // 게임 시작 시 초기 로테이션 설정
        rotationX = rotationXs[0];
        transform.rotation = Quaternion.Euler(rotationX, 0, 0);
    }

    void Update()
    {
        if (int.TryParse(levelText.text, out int level) && level != currentLevel)
        {
            // 레벨이 유효한 범위 내인지 확인
            if (level >= 1 && level <= 11)
            {
                // 해당 레벨의 초기 오프셋 설정
                initialOffset = levelOffsets[level - 1];

                // 해당 레벨의 X축 회전 설정
                rotationX = rotationXs[level - 1];

                currentLevel = level; // 현재 레벨 업데이트
            }
        }

        // 카메라 위치 업데이트
        transform.position = target.position + initialOffset;

        // 카메라의 X축 회전 적용
        transform.rotation = Quaternion.Euler(rotationX, 0, 0);
    }
}