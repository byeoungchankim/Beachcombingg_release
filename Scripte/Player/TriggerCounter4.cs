using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerCounter4 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Ʈ���ſ� ���� ������Ʈ�� �±׸� Ȯ���Ͽ� ī��Ʈ ����
        if (other.CompareTag("Trash") || other.CompareTag("Trash2") ||
            other.CompareTag("Trash3") || other.CompareTag("Trash4") ||
            other.CompareTag("Trash5"))
        {
            CounterManager.Instance.IncreaseCount();  // ī��Ʈ ���� �Լ� ȣ��
        }
    }
}