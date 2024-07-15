using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineLVThree : MonoBehaviour
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
            if (obj == null) continue;

            Debug.Log("Object Tag: " + obj.tag); // �� ������Ʈ�� �±� �α�

            if (obj.CompareTag("Trash") || obj.CompareTag("Trash2") || obj.CompareTag("Trash3"))
            {
                Outline outline = obj.GetComponent<Outline>();
                if (outline != null)
                {
                    float distance = Vector3.Distance(transform.position, obj.transform.position);
                    outline.enabled = distance <= detectionRadius;
                    Debug.Log("Outline enabled for " + obj.name + " at distance " + distance); // ������Ʈ�� �Ÿ� �α�
                }
                else
                {
                    Debug.Log("Outline component not found on " + obj.name);
                }
            }
        }
    }

    private void UpdateObjectList()
    {
        allObjects.Clear();  // ����Ʈ�� �ʱ�ȭ
        string[] tags = { "Trash", "Trash2", "Trash3" };

        foreach (string tag in tags)
        {
            GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag(tag);
            allObjects.AddRange(taggedObjects);
        }
    }
}