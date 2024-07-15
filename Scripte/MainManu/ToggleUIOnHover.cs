using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToggleUIOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject[] childUIs;

    public void OnPointerEnter(PointerEventData eventData)
    {
        SetChildrenActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        SetChildrenActive(false);
    }

    private void SetChildrenActive(bool isActive)
    {
        foreach (var child in childUIs)
        {
            child.SetActive(isActive);
        }
    }
}