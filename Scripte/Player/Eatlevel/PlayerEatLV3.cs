using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEatLV3 : MonoBehaviour
{
    public Slider slider; // 슬라이더를 인스펙터에서 할당
    public Animator animator;
    public GameObject particleEffectPrefab1;
    public GameObject particleEffectPrefab2;
    public GameObject particleEffectPrefab3;
    public GameObject particleEffectPrefablv1;
    public GameObject particleEffectPrefablv2;
    public GameObject particleEffectPrefablv3;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trash"))
        {
            animator.SetBool("Attack", true);
            Vector3 position = other.transform.position;
            ProcessTrash(other.gameObject, 0.006f);
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
            ProcessTrash(other.gameObject, 0.01f);
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
            ProcessTrash(other.gameObject, 0.05f);
            StartCoroutine(ResetEatAnimation());

            // 첫 번째 파티클 효과 생성
            GameObject particleEffect5 = Instantiate(particleEffectPrefablv3, position, Quaternion.identity);
            Destroy(particleEffect5, 2.0f); // 2초 후 자동 소멸

            // 두 번째 파티클 효과 생성
            GameObject particleEffect6 = Instantiate(particleEffectPrefab3, position, Quaternion.identity);
            Destroy(particleEffect6, 2.0f); // 2초 후 자동 소멸

        }
        // 나머지 조건도 마찬가지로 추가
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

    private void InstantiateParticleEffect(GameObject prefab, Vector3 position, Vector3 scale)
    {
        GameObject effect = Instantiate(prefab, position, Quaternion.identity);
        effect.transform.localScale = scale; // 오브젝트의 크기에 맞추어 파티클 크기를 조정
        Destroy(effect, 2.0f); // 파티클은 2초 후에 자동 소멸
    }
}