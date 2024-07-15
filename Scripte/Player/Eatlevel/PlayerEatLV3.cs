using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEatLV3 : MonoBehaviour
{
    public Slider slider; // �����̴��� �ν����Ϳ��� �Ҵ�
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

            // ù ��° ��ƼŬ ȿ�� ����
            GameObject particleEffect1 = Instantiate(particleEffectPrefablv1, position, Quaternion.identity);
            Destroy(particleEffect1, 2.0f); // 2�� �� �ڵ� �Ҹ�

            // �� ��° ��ƼŬ ȿ�� ����
            GameObject particleEffect2 = Instantiate(particleEffectPrefab1, position, Quaternion.identity);
            Destroy(particleEffect2, 2.0f); // 2�� �� �ڵ� �Ҹ�
        }
        else if (other.gameObject.CompareTag("Trash2"))
        {
            animator.SetBool("Attack", true);
            Vector3 position = other.transform.position;
            ProcessTrash(other.gameObject, 0.01f);
            StartCoroutine(ResetEatAnimation());

            // ù ��° ��ƼŬ ȿ�� ����
            GameObject particleEffect3 = Instantiate(particleEffectPrefablv2, position, Quaternion.identity);
            Destroy(particleEffect3, 2.0f); // 2�� �� �ڵ� �Ҹ�

            // �� ��° ��ƼŬ ȿ�� ����
            GameObject particleEffect4 = Instantiate(particleEffectPrefab2, position, Quaternion.identity);
            Destroy(particleEffect4, 2.0f); // 2�� �� �ڵ� �Ҹ�

        }
        else if (other.gameObject.CompareTag("Trash3"))
        {
            animator.SetBool("Attack", true);
            Vector3 position = other.transform.position;
            ProcessTrash(other.gameObject, 0.05f);
            StartCoroutine(ResetEatAnimation());

            // ù ��° ��ƼŬ ȿ�� ����
            GameObject particleEffect5 = Instantiate(particleEffectPrefablv3, position, Quaternion.identity);
            Destroy(particleEffect5, 2.0f); // 2�� �� �ڵ� �Ҹ�

            // �� ��° ��ƼŬ ȿ�� ����
            GameObject particleEffect6 = Instantiate(particleEffectPrefab3, position, Quaternion.identity);
            Destroy(particleEffect6, 2.0f); // 2�� �� �ڵ� �Ҹ�

        }
        // ������ ���ǵ� ���������� �߰�
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
        yield return new WaitForSeconds(1); // '1'�� �ִϸ��̼��� ���̿� ���� ����
        animator.SetBool("Attack", false);
    }

    private void InstantiateParticleEffect(GameObject prefab, Vector3 position, Vector3 scale)
    {
        GameObject effect = Instantiate(prefab, position, Quaternion.identity);
        effect.transform.localScale = scale; // ������Ʈ�� ũ�⿡ ���߾� ��ƼŬ ũ�⸦ ����
        Destroy(effect, 2.0f); // ��ƼŬ�� 2�� �Ŀ� �ڵ� �Ҹ�
    }
}