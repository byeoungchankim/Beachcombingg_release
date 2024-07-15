using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject wavePrefab;
    public float spawnInterval = 5f; // �ĵ� ���� ����
    public float spawnChance = 0.5f; // �ĵ��� ������ Ȯ�� (0���� 1 ����)

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            timer = 0f;
            if (Random.value < spawnChance) // Ȯ�� üũ
            {
                Instantiate(wavePrefab, transform.position, Quaternion.identity);
            }
        }
    }
}