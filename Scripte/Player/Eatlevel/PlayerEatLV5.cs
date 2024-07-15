using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEatLV5 : MonoBehaviour
{
    public Slider slider; // 슬라이더를 인스펙터에서 할당
    public Animator animator;
    public GameObject particleEffectPrefab1;
    public GameObject particleEffectPrefab2;
    public GameObject particleEffectPrefab3;
    public GameObject particleEffectPrefab4;
    public GameObject particleEffectPrefab5;
    public GameObject particleEffectPrefablv1;
    public GameObject particleEffectPrefablv2;
    public GameObject particleEffectPrefablv3;
    public GameObject particleEffectPrefablv4;
    public GameObject particleEffectPrefablv5;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trash"))
        {
            animator.SetBool("Attack", true);
            Vector3 position = other.transform.position;
            ProcessTrash(other.gameObject, 0.001f);
            StartCoroutine(ResetEatAnimation());

            // 첫 번째 파티클 효과 생성
            GameObject particleEffect1 = Instantiate(particleEffectPrefablv1, position, Quaternion.identity);
            Destroy(particleEffect1, 2.0f); // 2초 후 자동 소멸

            // 두 번째 파티클 효과 생성
            GameObject particleEffect2 = Instantiate(particleEffectPrefab1, position, Quaternion.identity);
            Destroy(particleEffect2, 2.0f); // 2초 후 자동 소멸
        }
        else if (other.gameObject.CompareTag("Trash2"))
        {
            animator.SetBool("Attack", true);
            Vector3 position = other.transform.position;
            ProcessTrash(other.gameObject, 0.002f);
            StartCoroutine(ResetEatAnimation());

            // 첫 번째 파티클 효과 생성
            GameObject particleEffect3 = Instantiate(particleEffectPrefablv2, position, Quaternion.identity);
            Destroy(particleEffect3, 2.0f); // 2초 후 자동 소멸

            // 두 번째 파티클 효과 생성
            GameObject particleEffect4 = Instantiate(particleEffectPrefab2, position, Quaternion.identity);
            Destroy(particleEffect4, 2.0f); // 2초 후 자동 소멸

        }
        else if (other.gameObject.CompareTag("Trash3"))
        {
            animator.SetBool("Attack", true);
            Vector3 position = other.transform.position;
            ProcessTrash(other.gameObject, 0.01f);
            StartCoroutine(ResetEatAnimation());

            // 첫 번째 파티클 효과 생성
            GameObject particleEffect5 = Instantiate(particleEffectPrefablv3, position, Quaternion.identity);
            Destroy(particleEffect5, 2.0f); // 2초 후 자동 소멸

            // 두 번째 파티클 효과 생성
            GameObject particleEffect6 = Instantiate(particleEffectPrefab3, position, Quaternion.identity);
            Destroy(particleEffect6, 2.0f); // 2초 후 자동 소멸

        }
        else if (other.gameObject.CompareTag("Trash4"))
        {
            animator.SetBool("Attack", true);
            Vector3 position = other.transform.position;
            ProcessTrash(other.gameObject, 0.07f);
            StartCoroutine(ResetEatAnimation());

            // 첫 번째 파티클 효과 생성
            GameObject particleEffect7 = Instantiate(particleEffectPrefablv4, position, Quaternion.identity);
            Destroy(particleEffect7, 2.0f); // 2초 후 자동 소멸

            // 두 번째 파티클 효과 생성
            GameObject particleEffect8 = Instantiate(particleEffectPrefab4, position, Quaternion.identity);
            Destroy(particleEffect8, 2.0f); // 2초 후 자동 소멸
        }
        else if (other.gameObject.CompareTag("Trash5"))
        {
            animator.SetBool("Attack", true);
            Vector3 position = other.transform.position;
            ProcessTrash(other.gameObject, 0.07f);
            StartCoroutine(ResetEatAnimation());

            // 첫 번째 파티클 효과 생성
            GameObject particleEffect9 = Instantiate(particleEffectPrefablv5, position, Quaternion.identity);
            Destroy(particleEffect9, 2.0f); // 2초 후 자동 소멸

            // 두 번째 파티클 효과 생성
            GameObject particleEffect10 = Instantiate(particleEffectPrefab5, position, Quaternion.identity);
            Destroy(particleEffect10, 2.0f); // 2초 후 자동 소멸
        }
        StartCoroutine(ResetEatAnimation());
    }

    private void ProcessTrash(GameObject trash, float increment)
    {
        Destroy(trash);
        if (slider.value <= slider.maxValue - increment)
        {
            slider.value += increment;
        }
        else
        {
            slider.value = slider.maxValue;
        }
    }

    private IEnumerator ResetEatAnimation()
    {
        yield return new WaitForSeconds(1); // '1'은 애니메이션의 길이에 따라 조정
        animator.SetBool("Attack", false);
    }
}