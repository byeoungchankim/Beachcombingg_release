using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject wavePrefab;
    public float spawnInterval = 5f; // 파도 생성 간격
    public float spawnChance = 0.5f; // 파도가 생성될 확률 (0에서 1 사이)

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            timer = 0f;
            if (Random.value < spawnChance) // 확률 체크
            {
                Instantiate(wavePrefab, transform.position, Quaternion.identity);
            }
        }
    }
}