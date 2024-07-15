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
            if (obj == null) continue; // 오브젝트가 null인 경우 무시

            // "Trash" 또는 "Trash2" 태그를 확인
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
        allObjects.Clear();  // 리스트를 초기화

        // "Trash" 태그가 있는 게임 오브젝트만 찾아서 추가
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Trash"))
        {
            allObjects.Add(obj);
        }

        // "Trash2" 태그가 있는 게임 오브젝트만 찾아서 추가
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Trash2"))
        {
            allObjects.Add(obj);
        }
    }
}