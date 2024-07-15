using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerCounter1 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // 트리거에 들어온 오브젝트의 태그를 확인하여 카운트 증가
        if (other.CompareTag("Trash") ||  other.CompareTag("Trash2"))
        {
            CounterManager.Instance.IncreaseCount();  // 카운트 증가 함수 호출
        }
    }
}