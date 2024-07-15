using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEat : MonoBehaviour
{
    public Slider slider; // 슬라이더를 인스펙터에서 할당
    public Animator animator;
    public GameObject particleEffectPrefab;
    public GameObject particleEffectPrefab2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trash"))
        {
            animator.SetBool("Attack", true);
            Vector3 position = other.transform.position;
            ProcessTrash(other.gameObject, 0.05f);

            // GameManager를 사용하여 코루틴 시작
            if (GameManager.Instance != null)
            {
                GameManager.Instance.StartCoroutineFromManager(ResetEatAnimation());
            }

            // 첫 번째 파티클 효과 생성
            GameObject particleEffect1 = Instantiate(particleEffectPrefab, position, Quaternion.identity);
            Destroy(particleEffect1, 2.0f); // 2초 후 자동 소멸

            // 두 번째 파티클 효과 생성
            GameObject particleEffect2 = Instantiate(particleEffectPrefab2, position, Quaternion.identity);
            Destroy(particleEffect2, 2.0f); // 2초 후 자동 소멸
        }
        // 나머지 조건도 마찬가지로 추가
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
        // 여기에 추가적인 기능을 넣을 거임
    }

    private IEnumerator ResetEatAnimation()
    {
        yield return new WaitForSeconds(1); // '1'은 애니메이션의 길이에 따라 조정
        animator.SetBool("Attack", false);
    }
}