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
        // 매 프레임마다 오브젝트 리스트를 업데이트하지 않고, 필요할 때만 업데이트 하도록 구조를 변경할 수 있습니다.
        foreach (GameObject obj in allObjects)
        {
            if (obj == null) continue; // 오브젝트가 null인 경우 무시
            if (obj.CompareTag("Trash")) // 태그 확인
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
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Trash"))  // "Trash" 태그가 있는 게임 오브젝트만 찾아서 추가
        {
            allObjects.Add(obj);
        }
    }
}