using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; } // �̱��� �ν��Ͻ�

    public Camera mainCamera; // ���� ī�޶�
    public float[] speedLevels = new float[20] { 10f, 10f, 10f, 10f, 12f, 12f, 12f, 12f, 12f, 15f, 15f, 15f, 15f, 15f, 18f, 18f, 18f, 18f, 18f, 20f }; // ������ �ִ� �ӵ�
    public float rotationSpeed = 5.0f; // ȸ�� �ӵ� ����
    public Slider slider; // �����̴�
    public Text levelText;  // ������ ǥ���� �ؽ�Ʈ UI

    private Vector3 dir; // ����
    private int currentLevel = 1; // ���� ����, �ʱⰪ 1

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this; // �̱��� �ν��Ͻ� ����
        }
        else
        {
            Destroy(gameObject); // �̹� �ν��Ͻ��� �����ϸ� �ı�
        }
    }

    private void Update()
    {
        int level;
        if (int.TryParse(levelText.text, out level) && level != currentLevel)
        {
            if (level >= 1 && level <= 20)
            {
                currentLevel = level; // ���� ���� ������Ʈ
            }
        }

        float maxSpeed = speedLevels[currentLevel - 1]; // ���� ������ �´� �ִ� �ӵ� ���

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Vector3 targetPos = hit.point;
            targetPos.y = transform.position.y; // ������Ʈ�� y ��ġ�� ����
            Vector3 targetDirection = targetPos - transform.position; // Ÿ�� ���� ���� ���

            if (targetDirection != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(targetDirection); // Ÿ�� ������ �ٶ󺸴� ȸ�� ����
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime); // ���� ȸ������ ��ǥ ȸ������ �ε巴�� ��ȯ
            }

            dir = targetDirection.normalized; // �̵� ���� ����
            transform.Translate(dir * maxSpeed * Time.deltaTime, Space.World); // �������� �̵�, �ִ� �ӵ��� ��� �̵�
        }
    }
}