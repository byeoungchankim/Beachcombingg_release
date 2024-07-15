using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHit : MonoBehaviour
{
    public Slider slider; // �����̴��� �ν����Ϳ��� �Ҵ�
    public Animator animator;
    public GameObject particleEffectPrefab;
    public GameObject particleStenEffectPrefab;
    public bool isStunned = false; // ���� ���¸� ��Ÿ���� ����
    public PlayerController playerController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            if (!isStunned) // ���� ���°� �ƴ� ���� ó��
            {
                animator.SetBool("Hit", true);
                Vector3 position = other.transform.position;
                ProcessTrash(other.gameObject, 0.05f);
                StartCoroutine(ResetEatAnimation());
                StartCoroutine(DisableScript(5.0f));

                // ��ƼŬ ȿ�� ����
                //GameObject particleEffect = Instantiate(particleEffectPrefab, position, Quaternion.identity);
                PlayerparticleEffect();
                //Destroy(particleEffect, 2.0f); // 2�� �Ŀ� ��ƼŬ ȿ�� �ڵ� �Ҹ�

                // ���� �ڷ�ƾ ����
                //StartCoroutine(Stun(2.0f)); // 2�ʰ� ����
            }
        }
        // ������ ���ǵ� ���������� �߰�
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
        // ���⿡ �߰����� ����� ���� ����
    }

    private IEnumerator ResetEatAnimation()
    {
        yield return new WaitForSeconds(1); // '1'�� �ִϸ��̼��� ���̿� ���� ����
        animator.SetBool("Hit", false);
    }

    private IEnumerator Stun(float duration)
    {
        isStunned = true;  // ���� ���·� ��ȯ
        // ���� ���� ó��, ���� ��� �Է� ���� ��
        yield return new WaitForSeconds(duration);  // ���� ���� �ð�
        isStunned = false;  // ���� ���� ����
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
        playerController.enabled = false;  // ��ũ��Ʈ ��Ȱ��ȭ
        yield return new WaitForSeconds(duration);  // ������ �ð� ���� ���
        playerController.enabled = true;  // ��ũ��Ʈ ��Ȱ��ȭ
    }
}