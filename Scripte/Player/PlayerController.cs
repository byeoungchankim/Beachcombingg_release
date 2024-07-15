using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; } // 싱글톤 인스턴스

    public Camera mainCamera; // 메인 카메라
    public float[] speedLevels = new float[20] { 10f, 10f, 10f, 10f, 12f, 12f, 12f, 12f, 12f, 15f, 15f, 15f, 15f, 15f, 18f, 18f, 18f, 18f, 18f, 20f }; // 레벨별 최대 속도
    public float rotationSpeed = 5.0f; // 회전 속도 조절
    public Slider slider; // 슬라이더
    public Text levelText;  // 레벨을 표시할 텍스트 UI

    private Vector3 dir; // 방향
    private int currentLevel = 1; // 현재 레벨, 초기값 1

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this; // 싱글톤 인스턴스 설정
        }
        else
        {
            Destroy(gameObject); // 이미 인스턴스가 존재하면 파괴
        }
    }

    private void Update()
    {
        int level;
        if (int.TryParse(levelText.text, out level) && level != currentLevel)
        {
            if (level >= 1 && level <= 20)
            {
                currentLevel = level; // 현재 레벨 업데이트
            }
        }

        float maxSpeed = speedLevels[currentLevel - 1]; // 현재 레벨에 맞는 최대 속도 사용

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Vector3 targetPos = hit.point;
            targetPos.y = transform.position.y; // 오브젝트의 y 위치를 고정
            Vector3 targetDirection = targetPos - transform.position; // 타겟 방향 벡터 계산

            if (targetDirection != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(targetDirection); // 타겟 방향을 바라보는 회전 생성
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime); // 현재 회전에서 목표 회전으로 부드럽게 전환
            }

            dir = targetDirection.normalized; // 이동 방향 설정
            transform.Translate(dir * maxSpeed * Time.deltaTime, Space.World); // 전방으로 이동, 최대 속도로 즉시 이동
        }
    }
}