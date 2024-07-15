using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineLVTwo : MonoBehaviour
{
    public float detectionRadius = 5.0f;
    private List<GameObject> allObjects = new List<GameObject>();

    void Start()
    {
        UpdateObjectList();
    }

    void Update()
    {
        foreach (GameObject obj in allObjects)
        {
            if (obj == null) continue; // ������Ʈ�� null�� ��� ����

            // "Trash" �Ǵ� "Trash2" �±׸� Ȯ��
            if (obj.CompareTag("Trash") || obj.CompareTag("Trash2"))
            {
                Outline outline = obj.GetComponent<Outline>();
                if (outline != null)
                {
                    float distance = Vector3.Distance(transform.position, obj.transform.position);
                    outline.enabled = distance <= detectionRadius;
                }
            }
        }
    }

    private void UpdateObjectList()
    {
        allObjects.Clear();  // ����Ʈ�� �ʱ�ȭ

        // "Trash" �±װ� �ִ� ���� ������Ʈ�� ã�Ƽ� �߰�
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Trash"))
        {
            allObjects.Add(obj);
        }

        // "Trash2" �±װ� �ִ� ���� ������Ʈ�� ã�Ƽ� �߰�
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Trash2"))
        {
            allObjects.Add(obj);
        }
    }
}