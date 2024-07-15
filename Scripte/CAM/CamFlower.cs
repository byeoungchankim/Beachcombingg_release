using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamFlower : MonoBehaviour
{
    public Transform target; // ī�޶� ���� ���
    public Vector3 initialOffset; // �ʱ� ������
    public int currentLevel; // ���� ����
    public Text levelText; // ������ ǥ���� �ؽ�Ʈ UI

    private Vector3[] levelOffsets = {
        new Vector3(0, 1, -3), // ���� 1
        new Vector3(0, 2f, -4f), // ���� 2
        new Vector3(0, 6, -8f), // ���� 3
        new Vector3(0, 10f, -12f), // ���� 4
        new Vector3(0, 20, -20f), // ���� 5
        new Vector3(0, 25f, -24f), // ���� 6
        new Vector3(0, 30f, -28f), // ���� 7
        new Vector3(0, 60f, -30f), // ���� 8
        new Vector3(0, 80f, -40f), // ���� 9
        new Vector3(0, 100f, -50f), // ���� 10
         
    };

    private float[] rotationXs = {
        1f, // ���� 1
        10f, // ���� 2
        20f, // ���� 3
        25f, // ���� 4
        30f, // ���� 5
        35f, // ���� 6
        40f, // ���� 7
        45f, // ���� 8
        50f, // ���� 9
        50f, // ���� 10
        50f // ���� 11
    };

    private float rotationX = 0f; // X�� ȸ���� ���� ����

    void Start()
    {
        // ���� ���� �� �ʱ� ������ ����
        initialOffset = levelOffsets[0];

        // ���� ���� �� �ʱ� �����̼� ����
        rotationX = rotationXs[0];
        transform.rotation = Quaternion.Euler(rotationX, 0, 0);
    }

    void Update()
    {
        if (int.TryParse(levelText.text, out int level) && level != currentLevel)
        {
            // ������ ��ȿ�� ���� ������ Ȯ��
            if (level >= 1 && level <= 11)
            {
                // �ش� ������ �ʱ� ������ ����
                initialOffset = levelOffsets[level - 1];

                // �ش� ������ X�� ȸ�� ����
                rotationX = rotationXs[level - 1];

                currentLevel = level; // ���� ���� ������Ʈ
            }
        }

        // ī�޶� ��ġ ������Ʈ
        transform.position = target.position + initialOffset;

        // ī�޶��� X�� ȸ�� ����
        transform.rotation = Quaternion.Euler(rotationX, 0, 0);
    }
}