using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerCounter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Ʈ���ſ� ���� ������Ʈ�� �±׸� Ȯ���Ͽ� ī��Ʈ ����
        if (other.CompareTag("Trash"))
        {
            CounterManager.Instance.IncreaseCount();  // ī��Ʈ ���� �Լ� ȣ��
        }
    }
}