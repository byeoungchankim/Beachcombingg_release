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

            Debug.Log("Object Tag: " + obj.tag); // 각 오브젝트의 태그 로깅

            if (obj.CompareTag("Trash") || obj.CompareTag("Trash2") || obj.CompareTag("Trash3"))
            {
                Outline outline = obj.GetComponent<Outline>();
                if (outline != null)
                {
                    float distance = Vector3.Distance(transform.position, obj.transform.position);
                    outline.enabled = distance <= detectionRadius;
                    Debug.Log("Outline enabled for " + obj.name + " at distance " + distance); // 오브젝트와 거리 로깅
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
        allObjects.Clear();  // 리스트를 초기화
        string[] tags = { "Trash", "Trash2", "Trash3" };

        foreach (string tag in tags)
        {
            GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag(tag);
            allObjects.AddRange(taggedObjects);
        }
    }
}