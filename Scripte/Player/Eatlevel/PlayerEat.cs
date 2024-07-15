using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEat : MonoBehaviour
{
    public Slider slider; // �����̴��� �ν����Ϳ��� �Ҵ�
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

            // GameManager�� ����Ͽ� �ڷ�ƾ ����
            if (GameManager.Instance != null)
            {
                GameManager.Instance.StartCoroutineFromManager(ResetEatAnimation());
            }

            // ù ��° ��ƼŬ ȿ�� ����
            GameObject particleEffect1 = Instantiate(particleEffectPrefab, position, Quaternion.identity);
            Destroy(particleEffect1, 2.0f); // 2�� �� �ڵ� �Ҹ�

            // �� ��° ��ƼŬ ȿ�� ����
            GameObject particleEffect2 = Instantiate(particleEffectPrefab2, position, Quaternion.identity);
            Destroy(particleEffect2, 2.0f); // 2�� �� �ڵ� �Ҹ�
        }
        // ������ ���ǵ� ���������� �߰�
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
        // ���⿡ �߰����� ����� ���� ����
    }

    private IEnumerator ResetEatAnimation()
    {
        yield return new WaitForSeconds(1); // '1'�� �ִϸ��̼��� ���̿� ���� ����
        animator.SetBool("Attack", false);
    }
}