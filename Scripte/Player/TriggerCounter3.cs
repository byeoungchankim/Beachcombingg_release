using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerCounter3 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Ʈ���ſ� ���� ������Ʈ�� �±׸� Ȯ���Ͽ� ī��Ʈ ����
        if (other.CompareTag("Trash") || other.CompareTag("Trash2") ||
            other.CompareTag("Trash3") || other.CompareTag("Trash4"))
        {
            CounterManager.Instance.IncreaseCount();  // ī��Ʈ ���� �Լ� ȣ��
        }
    }
}