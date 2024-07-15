using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeachBallSpawner : MonoBehaviour
{
    public Transform firePoint;  // 발사 위치
    public GameObject bombPrefab;  // 폭탄 프리팹
    public float launchForce = 1000f;  // 발사력
    public Transform[] targetObjects;  // 목표 오브젝트 배열

    void Start()
    {
        if (targetObjects.Length > 0)
        {
            // 1초 후 첫 발사를 시작하여 1초 간격으로 반복 발사
            InvokeRepeating("LaunchBomb", 2.0f, 2.0f);
        }
    }

    void LaunchBomb()
    {
        if (targetObjects.Length == 0) return;

        // 무작위 오브젝트 위치 선택
        Transform target = targetObjects[Random.Range(0, targetObjects.Length)];

        // 폭탄 생성
        GameObject bomb = Instantiate(bombPrefab, firePoint.position, firePoint.rotation);
        Rigidbody bombRb = bomb.GetComponent<Rigidbody>();

        // 대포를 무작위 선택된 오브젝트 위치로 조정
        firePoint.LookAt(target.position);

        // 폭탄에 힘을 가하여 발사
        bombRb.AddForce(firePoint.forward * launchForce, ForceMode.Impulse);

        Destroy(bomb, 10.0f);
    }
}