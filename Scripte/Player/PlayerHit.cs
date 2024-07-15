using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHit : MonoBehaviour
{
    public Slider slider; // 슬라이더를 인스펙터에서 할당
    public Animator animator;
    public GameObject particleEffectPrefab;
    public GameObject particleStenEffectPrefab;
    public bool isStunned = false; // 스턴 상태를 나타내는 변수
    public PlayerController playerController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            if (!isStunned) // 스턴 상태가 아닐 때만 처리
            {
                animator.SetBool("Hit", true);
                Vector3 position = other.transform.position;
                ProcessTrash(other.gameObject, 0.05f);
                StartCoroutine(ResetEatAnimation());
                StartCoroutine(DisableScript(5.0f));

                // 파티클 효과 생성
                //GameObject particleEffect = Instantiate(particleEffectPrefab, position, Quaternion.identity);
                PlayerparticleEffect();
                //Destroy(particleEffect, 2.0f); // 2초 후에 파티클 효과 자동 소멸

                // 스턴 코루틴 시작
                //StartCoroutine(Stun(2.0f)); // 2초간 스턴
            }
        }
        // 나머지 조건도 마찬가지로 추가
    }



    private void ProcessTrash(GameObject trash, float increment)
    {
        if (slider.value <= slider.maxValue - increment)
        {
            slider.value -= increment;
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
        animator.SetBool("Hit", false);
    }

    private IEnumerator Stun(float duration)
    {
        isStunned = true;  // 스턴 상태로 전환
        // 스턴 관련 처리, 예를 들어 입력 무시 등
        yield return new WaitForSeconds(duration);  // 스턴 지속 시간
        isStunned = false;  // 스턴 상태 해제
    }


    private void PlayerparticleEffect()
    {
        if (gameObject.CompareTag("Player"))
        {
            Vector3 position = gameObject.transform.position;
            GameObject particleEffect = Instantiate(particleEffectPrefab, position, Quaternion.identity);
            Destroy(particleEffect, 2.0f);

        }
    }

    private IEnumerator DisableScript(float duration)
    {
        playerController.enabled = false;  // 스크립트 비활성화
        yield return new WaitForSeconds(duration);  // 지정된 시간 동안 대기
        playerController.enabled = true;  // 스크립트 재활성화
    }
}