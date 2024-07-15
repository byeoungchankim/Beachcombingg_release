using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeachBallSpawner : MonoBehaviour
{
    public Transform firePoint;  // �߻� ��ġ
    public GameObject bombPrefab;  // ��ź ������
    public float launchForce = 1000f;  // �߻��
    public Transform[] targetObjects;  // ��ǥ ������Ʈ �迭

    void Start()
    {
        if (targetObjects.Length > 0)
        {
            // 1�� �� ù �߻縦 �����Ͽ� 1�� �������� �ݺ� �߻�
            InvokeRepeating("LaunchBomb", 2.0f, 2.0f);
        }
    }

    void LaunchBomb()
    {
        if (targetObjects.Length == 0) return;

        // ������ ������Ʈ ��ġ ����
        Transform target = targetObjects[Random.Range(0, targetObjects.Length)];

        // ��ź ����
        GameObject bomb = Instantiate(bombPrefab, firePoint.position, firePoint.rotation);
        Rigidbody bombRb = bomb.GetComponent<Rigidbody>();

        // ������ ������ ���õ� ������Ʈ ��ġ�� ����
        firePoint.LookAt(target.position);

        // ��ź�� ���� ���Ͽ� �߻�
        bombRb.AddForce(firePoint.forward * launchForce, ForceMode.Impulse);

        Destroy(bomb, 10.0f);
    }
}