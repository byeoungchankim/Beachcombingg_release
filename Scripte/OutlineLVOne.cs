using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineLVOne : MonoBehaviour
{
    public float detectionRadius = 5.0f;
    private List<GameObject> allObjects = new List<GameObject>();

    void Start()
    {
        UpdateObjectList();
    }

    void Update()
    {
        // �� �����Ӹ��� ������Ʈ ����Ʈ�� ������Ʈ���� �ʰ�, �ʿ��� ���� ������Ʈ �ϵ��� ������ ������ �� �ֽ��ϴ�.
        foreach (GameObject obj in allObjects)
        {
            if (obj == null) continue; // ������Ʈ�� null�� ��� ����
            if (obj.CompareTag("Trash")) // �±� Ȯ��
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
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Trash"))  // "Trash" �±װ� �ִ� ���� ������Ʈ�� ã�Ƽ� �߰�
        {
            allObjects.Add(obj);
        }
    }
}